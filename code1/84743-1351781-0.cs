    public partial class Form1 : Form
    {
        int count;
        Thread t = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void ProcessLogic()
        {           
            //CPU intensive loop, if this were in the main thread
            //UI hangs...
            while (true)
            {
                count++;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Cannot directly call ProcessLogic, hangs UI thread.
            //ProcessLogic();
            //instead, run it in another thread and poll needed values
            //see button1_Click
            t = new Thread(ProcessLogic);
            t.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = count.ToString();
        }
    }
