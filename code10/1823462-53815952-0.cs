            Process process = new Process();
            try
            {
                // Configure the process using the StartInfo properties.
                process.StartInfo.FileName = "chrome1.exe";
                process.StartInfo.Arguments = "-n";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                process.Start();
                process.WaitForExit();// Waits here for the process to exit.
            }
            catch (Win32Exception ex)
            {
                if (ex.Message.Equals("The system cannot find the file specified"))
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        process.StartInfo.FileName = openFileDialog1.FileName;
                        process.Start();
                    }
                }
            }
