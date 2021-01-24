    public partial class MainWindow : Window
    {
        Logger logger;
        public MainWindow()
        {
            InitializeComponent();
            logger = new Logger(this);
        }
        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            ProcessFlow processFlow = new ProcessFlow(logger);
            await processFlow.Start();
        }
    }
    class ProcessFlow
    {
        private readonly Logger logger;
        public ProcessFlow(Logger logger)
        {
            this.logger = logger;
        }
        public Task Start()
        {
            return Task.Run(
                async () =>
                {
                    await logger.Write("Opening App...");
                    ProcessStartInfo startInfo = new ProcessStartInfo(@"notepad.exe")
                    {
                        UseShellExecute = true
                    };
                    // startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    using (var process = Process.Start(startInfo))
                    {
                        await logger.WriteLine(" done!");
                        await Task.Delay(2000);
                        await logger.Write("Closing App...");
                        process.Kill();
                        await logger.WriteLine(" done!");
                    }       
                }
            );
        }
    }
    public class Logger
    {
        private readonly MainWindow window;
        public Logger(MainWindow window)
        {
            this.window = window;
        }
        public Task Write(string text)
        {
            return window.Dispatcher.InvokeAsync(() => window.textBox1.Text += text).Task;
        }
        public Task WriteLine(string text)
        {
            return window.Dispatcher.InvokeAsync(() => window.textBox1.Text += text + "\r\n").Task;
        }
    }
