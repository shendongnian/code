    using System.Management;
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            bgwDriveDetector.DoWork += bgwDriveDetector_DoWork;
            bgwDriveDetector.RunWorkerAsync();
        }
        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();
            MessageBox.Show(driveName + " inserted");
        }
        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();
            MessageBox.Show(driveName + " removed");
        }
        void bgwDriveDetector_DoWork(object sender, DoWorkEventArgs e)
        {
            var insertQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            var insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += DeviceInsertedEvent;
            insertWatcher.Start();
            var removeQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            var removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += DeviceRemovedEvent;
            removeWatcher.Start();
        }
    }
