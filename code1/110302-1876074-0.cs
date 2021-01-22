    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    
    }
