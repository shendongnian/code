    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //RunMeTillSomeoneClicks(); // !!! Stops the form from being shown.
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            RunMeTillSomeoneClicks();
        }
        private bool keepOnRunning = true;
        private void RunMeTillSomeoneClicks()
        {
            int v = 0;
            while (keepOnRunning && (v < 360))
            {
                v += 10;
                RunIt(v);
                System.Threading.Thread.Sleep(500);
                if (v == 360) { v = 0; }
                Application.DoEvents();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            keepOnRunning = false;
        }
        private void RunIt(int v)
        {
            label1.Text = v.ToString();
            Refresh();
        }
    }
