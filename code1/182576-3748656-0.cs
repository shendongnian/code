    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(filename);
                        psi.RedirectStandardOutput = true;
                        psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        psi.UseShellExecute = false;
                        System.Diagnostics.Process listFiles;
                        listFiles = System.Diagnostics.Process.Start(psi);
                        System.IO.StreamReader myOutput = listFiles.StandardOutput;
                        listFiles.WaitForExit(2000);
                        if (listFiles.HasExited)
                        {
                            string output = myOutput.ReadToEnd();
                            MessageBox.Show(output);
                        }
