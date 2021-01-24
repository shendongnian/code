    public partial class Form1 : Form
    {
        bool cancel;
        public Form1()
        {
            InitializeComponent();
        }
        public void StartPinging()
        {
            this.cancel = false;
            startButton.Enabled = false;
            stopButton.Enabled = true;
            responseBox.Clear();
            responseBox.AppendText("Starting to ping server.");
            responseBox.AppendText(Environment.NewLine);
            var bw = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = true
            };
            bw.DoWork += (obj, ev) =>
            {
                while (!cancel)
                {
                    // Ping Server Here
                    string response = Server.PingServer();
                    this.Invoke(new UiMethod(() =>
                    {
                        responseBox.AppendText(response);
                        responseBox.AppendText(Environment.NewLine);
                    }));
                }
            };
            bw.RunWorkerCompleted += (obj, ev) =>
            {
                this.Invoke(new UiMethod(() =>
                {
                    responseBox.AppendText("Stopped pinging the server.");
                    responseBox.AppendText(Environment.NewLine);
                    startButton.Enabled = true;
                    stopButton.Enabled = false;
                }));
            };
            bw.RunWorkerAsync();
        }
        delegate void UiMethod();
        private void startButton_Click(object sender, EventArgs e)
        {
            StartPinging();
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            responseBox.AppendText("Cancelation Pressed.");
            responseBox.AppendText(Environment.NewLine);
            cancel = true;
        }
    }
    public class Server
    {
        static Random rng = new Random();
        public static string PingServer()
        {
            int time = 1200 + rng.Next(2400);
            Thread.Sleep(time);
            return $"{time} ms";
        }
    }
