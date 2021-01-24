    public partial class Form1 : Form
    {
        //Data which need to be shown in list view 
        //and also need to pass to form3 (class3)
        public List<string> Data = new List<string>();
        public Form1()
        {
            InitializeComponent();
            Data.Add("item1");
            Data.Add("item2");
        }
        private void btnForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
    }
