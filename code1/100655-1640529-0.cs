    namespace BackgroundWorkerExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                Thread.Sleep(1000);
                MessageBox.Show("Now!");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //Now it works!
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
