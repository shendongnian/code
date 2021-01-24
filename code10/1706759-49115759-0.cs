            try
            {
                ProcessStartInfo startInfo;
                startInfo = new ProcessStartInfo();
                startInfo.FileName = Path.Combine
                (Path.GetDirectoryName(Application.ExecutablePath), "GladeInstaller.exe");
                startInfo.Arguments =
                string.Empty;
                startInfo.UseShellExecute = true;
                startInfo.Verb = "runas";
                Process.Start(startInfo);
            }
            catch (Exception)
            {
                MessageBox.Show("The installer needs to be ran as administraitor in order for it to work, if you dont have theese priverlages download Glade Skinned", "Glade Installation Error");
                Environment.Exit(0);
            }
            string path = @"c:\Glade";
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    MessageBox.Show("The directory C:\\Glade allready exists! Delecte the folder C:\\Glade and re-run the installer");
                    // This part was killing you application 
                    // now it just ends click event without killing application.
                    
                    //Application.Exit();
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName("Glade Installer"))
                        {
                            proc.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Installation finished!", "Glade Installer");
                    Application.Exit();
                }
            }
            catch (Exception ec)
            {
                Console.WriteLine("The process failed: {0}", ec.ToString());
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("Glade Installer"))
                    {
                        proc.Kill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Environment.Exit(0);
            }
