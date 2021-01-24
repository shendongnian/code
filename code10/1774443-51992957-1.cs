    private void RunSysprep()
        {
            try
            {
                if (Wow64Interop.EnableWow64FSRedirection(true) == true)
                {
                    Wow64Interop.EnableWow64FSRedirection(false);
                }
                Process Sysprep = new Process();
                Sysprep.StartInfo.FileName = "C:\\Windows\\System32\\Sysprep\\sysprep.exe";
                Sysprep.StartInfo.Arguments = "/generalize /oobe /shutdown /unattend:\"C:\\Windows\\System32\\Sysprep\\unattend.xml\"";
                Sysprep.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                Sysprep.Start();
                if (Wow64Interop.EnableWow64FSRedirection(false) == true)
                {
                    Wow64Interop.EnableWow64FSRedirection(true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
