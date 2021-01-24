    static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartUp();            
        }
        static void StartUp()
        {
            bool mode = false;
            Application.Run(new Form1(mode));
            //bool playermode = GetPlayerMode(); 
        }
    
    namespace PencilProject
     {
    public partial class Form1 : Form 
    {
        private bool modebool;
        public Form1(bool modebool)
        {
            this.modebool = modebool;
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            modebool = true;            
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            modebool = false;
            Close();
        }
     }
    }
