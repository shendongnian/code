    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random m_random = new Random((int)DateTime.Now.Ticks);
        ManualResetEvent m_stopThreadsEvent = new ManualResetEvent(false);
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(ThreadOne));
            Thread t2 = new Thread(new ThreadStart(ThreadTwo));
            t1.Start();
            t2.Start();
        }
        private void ThreadOne()
        {
            for(;;)
            {
                int n = m_random.Next(1000);
                AppendText(String.Format("One: {0}\r\n", n));
                if(m_stopThreadsEvent.WaitOne(n))
                {
                    break;
                }
            }
        }
        private void ThreadTwo()
        {
            for(;;)
            {
                int n = m_random.Next(1000);
                AppendText(String.Format("Two: {0}\r\n", n));
                if(m_stopThreadsEvent.WaitOne(n))
                {
                    break;
                }
            }
        }
        delegate void AppendTextDelegate(string text);
        private void AppendText(string text)
        {
            if(textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new AppendTextDelegate(this.AppendText), new object[] { text });
            }
            else
            {
                textBoxLog.Text = textBoxLog.Text += text;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_stopThreadsEvent.Set();
        }
    }
