    //using Microsoft.Win32;
    //using System.Net.NetworkInformation;
    public class SessionChanges
    {
        public SessionChanges()
        {
            NetworkChange.NetworkAvailabilityChanged += 
                new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
        }
        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLogon)
            { 
                //user logged in
            }
        }
        void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            { 
                //a network is available
            }
        }
    }
