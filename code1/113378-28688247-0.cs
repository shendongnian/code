    public partial class Form1 : Form
    {
        private Thread SecondaryThread;
        public Form1()
        {
            InitializeComponent();
            OperationFinished += callback1;
            OperationFinished += callback2;
            OperationFinished += callback3;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            SecondaryThread = new Thread(new ThreadStart(SecondaryThreadMethod));
            SecondaryThread.Start();
        }
         private void SecondaryThreadMethod()
         {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            OnOperationFinished(new MessageEventArg("test1"));
            OnOperationFinished(new MessageEventArg("test2"));
            OnOperationFinished(new MessageEventArg("test3"));
            //This is where the program waits for whatever operations take
                 //place when OperationFinished is triggered.
            sw.Stop();
            Invoke((MethodInvoker)delegate
            {
                richTextBox1.Text += "Time taken (ms): " + sw.ElapsedMilliseconds + "\n";
            });
         }
        void callback1(object sender, MessageEventArg e)
        {
            Thread.Sleep(2000);
            Invoke((MethodInvoker)delegate
            {
                richTextBox1.Text += e.Message + "\n";
            });
        }
        void callback2(object sender, MessageEventArg e)
        {
            Thread.Sleep(2000);
            Invoke((MethodInvoker)delegate
            {
                richTextBox1.Text += e.Message + "\n";
            });
        }
        void callback3(object sender, MessageEventArg e)
        {
            Thread.Sleep(2000);
            Invoke((MethodInvoker)delegate
            {
                richTextBox1.Text += e.Message + "\n";
            });
        }
        public event EventHandler<MessageEventArg> OperationFinished;
        protected void OnOperationFinished(MessageEventArg e)
        {
            //##### Method1 - Event raised on the same thread ##### 
            //EventHandler<MessageEventArg> handler = OperationFinished;
            //if (handler != null)
            //{
            //    handler(this, e);
            //}
            //##### Method2 - Event raised on (the same) separate thread for all listener #####
            //EventHandler<MessageEventArg> handler = OperationFinished;
            //if (handler != null)
            //{
            //    Task.Factory.StartNew(() => handler(this, e));
            //}
            //##### Method3 - Event raised on different threads for each listener #####
            if (OperationFinished != null)
            {
                foreach (EventHandler<MessageEventArg> handler in OperationFinished.GetInvocationList())
                {
                    Task.Factory.FromAsync((asyncCallback, @object) => handler.BeginInvoke(this, e, asyncCallback, @object), handler.EndInvoke, null);
                }
            }
        }
    }
    public class MessageEventArg : EventArgs
    {
        public string Message { get; set; }
        public MessageEventArg(string message)
        {
            this.Message = message;
        }
    }
}
