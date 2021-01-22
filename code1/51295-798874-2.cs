    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate { MyWorker.Run(button1); }); 
        }
    }
    class MyWorker
    {
        public static void Run(Button button)
        {
            SynchronizedInvoker.Invoke(() => button.Text = "running");
            Thread.Sleep(5000); // do some important work here
            SynchronizedInvoker.Invoke(() => button.Text = "finished");
        }
    }
