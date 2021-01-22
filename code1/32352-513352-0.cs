    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private delegate void AddNewLogMessageEventHandler(string message);
        public void AddLogMessage(string message)
        {
            object[] args = new object[1];
            args[0] = message;
            if (InvokeRequired)
                BeginInvoke(new AddNewLogMessageEventHandler(AddLog), args);
            else
                Invoke(new AddNewLogMessageEventHandler(AddLog), args);
        }
        private void AddLog(string message)
        {
            this.Log.Items.Add(message);
        }
     }
