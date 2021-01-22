    using System;
    using System.Net.NetworkInformation;
    using Timer=System.Threading.Timer;
    namespace NetworkCheckApp
    {
    public class NetworkStatusObserver
    {
        public event EventHandler<EventArgs> NetworkChanged;
        private NetworkInterface[] oldInterfaces;
        private Timer timer;
        public void Start()
        {
            timer = new Timer(UpdateNetworkStatus, null, new TimeSpan(0, 0, 0, 0, 500), new TimeSpan(0, 0, 0, 0, 500));
            oldInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        }
        private void UpdateNetworkStatus(object o)
        {
            var newInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            bool hasChanges = false;
            if (newInterfaces.Length != oldInterfaces.Length)
            {
                hasChanges = true;
            }
            if (!hasChanges)
            {
                for (int i = 0; i < oldInterfaces.Length; i++)
                {
                    if (oldInterfaces[i].Name != newInterfaces[i].Name || oldInterfaces[i].OperationalStatus != newInterfaces[i].OperationalStatus)
                    {
                        hasChanges = true;
                        break;
                    }
                }
            }
            oldInterfaces = newInterfaces;
            if (hasChanges)
            {
                RaiseNetworkChanged();
            }
        }
        private void RaiseNetworkChanged()
        {
            if (NetworkChanged != null)
            {
                NetworkChanged.Invoke(this, null);
            }
        }
    }
    }
