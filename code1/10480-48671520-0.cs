        static void Disable(string interfaceName)
        {
            //set interface name="Ethernet" admin=DISABLE
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface name=" + interfaceName + " admin=DISABLE");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
        }
        static void Enable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface name=" + interfaceName + " admin=ENABLE");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
        }
