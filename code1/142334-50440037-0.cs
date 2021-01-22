    public partial class Form1 : Form
    {
        Splash splashscreen = new Splash();
        public Form1()
        {
            InitializeComponent();
            splashscreen.Show();
            Application.DoEvents();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            Thread.Sleep(4000);
            splashscreen.Close();
        }
    }
