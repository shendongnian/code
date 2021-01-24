    public partial class MainWindow : Window
    {
        MyConfigurationClass configuration;
        string filePath = @"./some.xml";
        FileSystemWatcher fileWatcher = new FileSystemWatcher();
        System.Timers.Timer timer = new System.Timers.Timer();
        public MainWindow()
        {
            // First read action action for 
            var task = Task.Run(() => ReadXML());
            InitializeComponent();
            FileWatherConfigure();
            TimerConfigure(task.Result);
        }
        private void FileWatherConfigure()
        {
            fileWatcher.Path = System.IO.Path.GetDirectoryName(filePath);
            fileWatcher.Filter = System.IO.Path.GetFileName(filePath);
            fileWatcher.Changed += FileWatcher_Changed;
            fileWatcher.EnableRaisingEvents = true;
        }
        private void TimerConfigure(SomeClass someClass)
        {
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = configuration.TimeInterval.TotalMilliseconds;
            timer.Enabled = true;
        }
        private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            SomeClass someClass = ReadXML();
            // Do whatever you want file change
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            try
            {
                // Schedule Operation
            }
            catch (Exception ex)
            {
            }
            timer.Start();
            
        }
        private SomeClass ReadXML()
        {
            // Read file and do what ever you want
        }
    }
    public class SomeClass
    {
        // Data from XML
    }
    public class MyConfigurationClass
    {
        public TimeSpan TimeInterval { get; set; }
    }
