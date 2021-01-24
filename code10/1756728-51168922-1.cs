    static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartUp();            
        }
        static void StartUp()
        {
            Form1 frm = new Form1()
            Application.Run(frm);
            bool mode = frm.DialogResult == DialogResult.Yes;
            //bool playermode = GetPlayerMode(); 
        }
    
    namespace PencilProject
     {
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            DialogResult == DialogResult.Yes;      
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult == DialogResult.No;
            Close();
        }
     }
    }
