    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CancellationTokenSource cancelSource;
        // Button is used to START the timer.
        private void TimerStartButton_Click(object sender, EventArgs e)
        {
            cancelSource = new CancellationTokenSource();
            // Run the below method that will initiate timer to start running from 
            // the button click.
            SystemEventLoggerTimer(cancelSource.Token);
        }
        private void SystemEventLoggerTimer(CancellationToken cancelToken)
        {
            Task.Run(async () =>
            {
                // Keep this task alive until it is cancelled
                while (!cancelToken.IsCancellationRequested)
                {
                    // Encapsulating the function Task.Delay with 'cancelToken'
                    // allows us to stop the Task.Delay during mid cycle.
                    // For testing purposes, have reduced the time interval to 2 secs.
                    await Task.Delay(TimeSpan.FromSeconds(2), cancelToken);
                    // Run the below method every 2 seconds.
                    CheckFileOverflow();
                }
            });
        }
        // When the below method runs every 2 secs, the UpdateUI will allow
        // us to modify the textbox form controls from another thread.
        private void CheckFileOverflow()
        {
            UpdateTextbox("Timer Running");
        }
        // UpdateUI will allow us to modify the textbox form controls from another thread.
        private void UpdateTextbox(string s)
        {
            Func<int> del = delegate ()
            {
                textBox1.AppendText(s + Environment.NewLine);
                return 0;
            };
            Invoke(del);
        }
        // Button that is used to STOP the timer running.
        private void TimerStopButton_Click(object sender, EventArgs e)
        {
            // Initiate the cancelleation request to method "SystemEventLoggerTimer"
            cancelSource.Cancel();
        }
    }
