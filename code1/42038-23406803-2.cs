    public partial class Form1 : Form
    {
        BasicClassThreadExample _example;
        public Form1()
        {
            InitializeComponent();
            _example = new BasicClassThreadExample();
            _example.MessageReceivedEvent += _example_MessageReceivedEvent;
        }
        void _example_MessageReceivedEvent(string command)
        {
            listBox1.Items.Add(command);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            _example.Start();
        }
    }
    public class BasicClassThreadExample : IDisposable
    {
        public delegate void MessageReceivedHandler(string msg);
        public event MessageReceivedHandler MessageReceivedEvent;
        protected virtual void OnMessageReceivedEvent(string msg)
        {
            MessageReceivedHandler handler = MessageReceivedEvent;
            if (handler != null)
            {
                handler(msg);
            }
        }
        private System.Threading.SynchronizationContext _SynchronizationContext;
        private System.Threading.Thread _doWorkThread;
        private bool disposed = false;
        public BasicClassThreadExample()
        {
            _SynchronizationContext = System.ComponentModel.AsyncOperationManager.SynchronizationContext;
        }
        public void Start()
        {
            _doWorkThread = _doWorkThread ?? new System.Threading.Thread(dowork);
            if (!(_doWorkThread.IsAlive))
            {
                _doWorkThread = new System.Threading.Thread(dowork);
                _doWorkThread.IsBackground = true;
                _doWorkThread.Start();
            }
        }
        public void dowork()
        {
            string[] retval = System.IO.Directory.GetFiles(@"C:\Windows\System32", "*.*", System.IO.SearchOption.TopDirectoryOnly);
            foreach (var item in retval)
            {
                System.Threading.Thread.Sleep(25);
                _SynchronizationContext.Post(new System.Threading.SendOrPostCallback(delegate(object obj)
                {
                    OnMessageReceivedEvent(item);
                }), null);
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _doWorkThread.Abort();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BasicClassThreadExample() { Dispose(false); }
    }
