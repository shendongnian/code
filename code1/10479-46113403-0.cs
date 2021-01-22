    private void Enable_LocalAreaConection(bool isEnable = true)
        {
            var interfaceName = "Local Area Connection";
            string control;
            if (isEnable)
                control = "enable";
            else
                control = "disable";
            System.Diagnostics.ProcessStartInfo psi =
                   new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" " + control);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
        }
