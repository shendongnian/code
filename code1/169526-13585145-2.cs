        public partial class Yekiler : Form
        {
        Utils Utility = new Utils();
        Form1 anaform = new Form1();
        
        public Yekiler()
        {
            InitializeComponent();
        }
        public void Yekiler_Load(object sender, EventArgs e)
        {
            anaform = Application.OpenForms["Form1"] as Form1;
            MessageBox.Show(anaform.GridOgrenci.ColumnCount.ToString()); 
