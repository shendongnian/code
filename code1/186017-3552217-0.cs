      public partial class Form1 : Form
    {
        System.Timers.Timer t = new System.Timers.Timer();
        Stack<string> urls = new Stack<string>();
        public Form1()
        {
            InitializeComponent();
            urls.Push("http://stackoverflow.com/");
            urls.Push("http://msdn.microsoft.com/");
            urls.Push("http://maps.google.com");
            t.AutoReset = false;
            t.Interval = 5000;
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            
        }
        
        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
             if (urls.Count > 0 )
            {
                 string url = urls.Pop();
                 SetUrl(url);
                    
             }
             t.Interval = 5000;
            t.Start();
           
        }
        static void SynchronizedInvoke(ISynchronizeInvoke sync, Action action)
        {
            // If the invoke is not required, then invoke here and get out.
            if (!sync.InvokeRequired)
            {
                // Execute action.
                action();
                // Get out.
                return;
            }
            // Marshal to the required thread.
            sync.Invoke(action, new object[] { });
        }
        private void SetUrl(string url)
        {
            SynchronizedInvoke(webBrowser1, () => webBrowser1.Navigate(url));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            t.Interval = 1;
            t.Start();
        }
      
    }
