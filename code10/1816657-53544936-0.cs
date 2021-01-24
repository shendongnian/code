    public partial class MenuForm : Form
    {
        Ventanas v = new Ventanas();
        EnfermoRep reporteEnfermo;
        public MenuForm()
        {
            InitializeComponent();
            reporteEnfermo = new EnfermoRep(this);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void rptEnfermo_Click(object sender, EventArgs e)
        {
            v.CargarVentana(reporteEnfermo, this.panel1);
        }
    } 
    public partial class EnfermoRep : Form
    {
        Ventanas v = new Ventanas();
        MenuForm menuForm;
        public EnfermoRep(MenuForm MF)
        {
            menuForm = MF;
            InitializeComponent();
        }
        private void EnfermoRep_Load(object sender, EventArgs e)
        {
            this.EnfermoTableAdapter.Fill(this.bd.Enfermo);
            this.reportViewer1.RefreshReport();
        }
        private void btnVolver1_Click(object sender, EventArgs e)
        {
            v.CargarVentanas(menuForm, this.enfermoRep);
        }
    }
