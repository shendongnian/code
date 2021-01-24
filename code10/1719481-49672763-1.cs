    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
  
        string textInst {get;set;}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textInst = textBox1.Text;
        }
    
    
    }
