    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread t;
        Form2 f2;
        private void button1_Click(object sender, EventArgs e)
        {
            t = new Thread(ThreadMethod);
            t.Start();
            button1.Enabled = false;
        }
        private void ShowForm()
        {
            f2 = new Form2();
            f2.ShowDialog();
        }
        private void ThreadMethod()
        {
            for (; ; )
            {
                Thread.Sleep(3000);
                if(f2 == null)
                {
                    BeginInvoke((Action)(() => { ShowForm(); }));
                }
                else
                {
                    f2.CloseMe();
                    f2 = null;
                }
            }
        }
    }
