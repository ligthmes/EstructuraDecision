namespace ContolRegistroDecision
{
    public partial class Form1 : Form
    {
        string dia;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Mostrando la fecha actual
            lblFecha.Text = DateTime.Now.ToShortDateString();

            //Determinar el dia 
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            dia = fecha.ToString("ddddd");

            double costo = 0;
            switch (dia)
            {
                case "domingo ": costo = 2; break;
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                    costo = 4; break;
                case "vienes":
                case "sabado":
                    costo = 7; break;
            }
            lblCosto.Text = costo.ToString("0.00");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Capturando los datos del formulario
            string placa = txtPlaca.Text;
            double costo = double.Parse(lblCosto.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime Horainicio = DateTime.Parse(txtHorainicio.Text);
            DateTime Horafin = DateTime.Parse(txtHorafin.Text);

            //calcular la hora
            TimeSpan hora = Horafin - Horainicio;

            //calular el importe 
            double importe = costo * (hora.TotalHours);

            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(Horainicio.ToString("t"));
            fila.SubItems.Add(Horafin.ToString("t"));
            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("C"));
            fila.SubItems.Add(importe.ToString("C"));
            lvRegistro.Items.Add(fila);







        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtHorafin.Clear();
            txtHorainicio.Clear();
            txtPlaca.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro ded salir ", "Estacionamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }
    }
}