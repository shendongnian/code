    delegate void ChangeColorDelegate(Color c);
    public partial class Form1 : Form
    {
        Thread thread;
        Boolean b;
        
        public Form1()
        {
            InitializeComponent();
            thread = new Thread(ChangeColorBackground);
            thread.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            b = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            b = false;
        }
        private void ChangeColorBackground()
        {
            while (true)
            {
                if (b == true)
                {
                    Random rnd = new Random();
                    int r = rnd.Next(0, 254);
                    int n = rnd.Next(0, 254);
                    int d = rnd.Next(0, 254);
                    Color c = Color.FromArgb(r, n, d);
                    ChangeColorThreadSafe(c);
                }
                System.Threading.Thread.Sleep(100);
            }
        }
        private void ChangeColorThreadSafe(Color c)
        {
            if (button1.InvokeRequired)
            {
                ChangeColorDelegate delgate = new ChangeColorDelegate(ChangeColorThreadSafe);
                button1.Invoke(delgate, new object[] { c });
            }
            else
            {
                this.BackColor = c;
            }
        }
    }
