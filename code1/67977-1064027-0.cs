    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // start a background thread that will never be exited.
            System.Threading.Thread thread = new System.Threading.Thread(delegate() { while (true) System.Threading.Thread.Sleep(1000); });
            thread.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
}
