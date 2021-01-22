      public class ProgressWorker<TArgument> : BackgroundWorker where TArgument : class 
        {
            public Action<TArgument> Action { get; set; }
    
            protected override void OnDoWork(DoWorkEventArgs e)
            {
                if (Action!=null)
                {
                    Action(e.Argument as TArgument);
                }
            }
        }
    public sealed partial class ProgressDlg<TArgument> : Form where TArgument : class
    {
        private readonly Action<TArgument> action;
        public Exception Error { get; set; }
        public ProgressDlg(Action<TArgument> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            this.action = action;
            InitializeComponent();
            //MaximumSize = Size;
            MaximizeBox = false;
            Closing += new System.ComponentModel.CancelEventHandler(ProgressDlg_Closing);
        }
        public string NotificationText
        {
            set
            {
                if (value!=null)
                {
                    Invoke(new Action<string>(s => Text = value));  
                }
                
            }
        }
        void ProgressDlg_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FormClosingEventArgs args = (FormClosingEventArgs)e;
            if (args.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
        
        private void ProgressDlg_Load(object sender, EventArgs e)
        {
			
        }
        public void RunWorker(TArgument argument)
        {
            System.Windows.Forms.Application.DoEvents();
            using (var worker = new ProgressWorker<TArgument> {Action = action})
            {
                worker.RunWorkerAsync();
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;                
                ShowDialog();
            }
        }
        void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Error = e.Error;
                DialogResult = DialogResult.Abort;
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
