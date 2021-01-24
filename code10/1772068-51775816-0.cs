    using System;
    using System.Management;
    
    /// <summary>
    /// Returns the number of monitors currently connected to the computer.
    /// </summary>
    /// <returns>(int) number of monitors</returns>
    public int getNumberOfConnectedMonitors() {
        int numberOfMonitors = 1;
        //Detect number of monitors. However, this does NOT work when no monitors are connected. It instead gives a 1.
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity where service =\"monitor\"");
        numberOfMonitors = searcher.Get().Count;
        //Get's the monitor's instance name. "Default_Monitor" is the "monitor" Windows defaults to when nothing is connected
        string activeScreen = "";
        using (var wmiSearcher = new ManagementObjectSearcher("\\root\\wmi", "select * from WmiMonitorBasicDisplayParams")) {
            var results = wmiSearcher.Get();
            foreach (ManagementObject wmiObj in results) {
                // tell us if the display is active
                var active = (Boolean)wmiObj["Active"];
                //Get the instance name of the active monitor
                if (active) {
                    activeScreen = (string)wmiObj["InstanceName"];
                }
            }
        }
        //If Windows says only one monitor is connected and that monitor is Default_Monitor, then that means that there are no monitors detected by Windows
        if(numberOfMonitors == 1 && activeScreen.Contains("Default_Monitor")) {
            numberOfMonitors = 0;
        }
            
        return numberOfMonitors;
    }
