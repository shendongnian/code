    using System.Collections.ObjectModel;
    using System.IO.Ports;
    using System.Management;
    public class ViewModel
    {
        private ManagementEventWatcher _watcher;
        public ViewModel()
        {
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent");
            _watcher = new ManagementEventWatcher(query);
            _watcher.EventArrived += (s, e) => RefreshPortNames();
            _watcher.Start();
        }
        public ObservableCollection<string> PortNames { get; } = new ObservableCollection<string>(SerialPort.GetPortNames());
        private void RefreshPortNames()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                PortNames.Clear();
                foreach (string portName in SerialPort.GetPortNames())
                {
                    PortNames.Add(portName);
                }
            });
        }
    }
