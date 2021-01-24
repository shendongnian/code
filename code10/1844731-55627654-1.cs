    Process MountProc = new Process();
                MountProc.StartInfo.CreateNoWindow = true;
                MountProc.StartInfo.UseShellExecute = false;
                MountProc.StartInfo.RedirectStandardOutput = true;
                MountProc.StartInfo.FileName = "mountvol";
                MountProc.StartInfo.RedirectStandardInput = true;
                MountProc.Start();
                MountProc.StandardInput.WriteLine("mountvol");
                MountProc.StandardInput.WriteLine("exit");
                string MountOutput = MountProc.StandardOutput.ReadToEnd();
                MountProc.WaitForExit();
    
                string VolumeGUID = string.Empty;
                List<string> VolList = MountOutput.Split(new string[] { "Possible values for VolumeName along with current mount points are:" }, StringSplitOptions.None)[1].Split('\n').Where(x => x != "\r").Where(x => x != "").ToList();
                List<string> ClearList = VolList.Select(s => s.Trim().Replace("\r", "")).ToList();
                for (int i = 0; i < ClearList.Count; i++)
                {
                    if (ClearList[i].StartsWith(@"\\?\Volume") && ClearList[i + 1].StartsWith("***")) 
                    {
                        string tmpPath = ClearList[i].Replace(@"\\?\", @"\\.\");
                        if (Directory.Exists(tmpPath))
                        {
                            string[] DirectoryList = Directory.GetDirectories(tmpPath, "*.*", SearchOption.TopDirectoryOnly);
                            string[] FileList = Directory.GetFiles(tmpPath, "*.*", SearchOption.TopDirectoryOnly);
    
                            if(DirectoryList.Length==0 && FileList.Length==1)
                            {
                                if (Path.GetExtension(FileList[0]) == ".license") 
                                {
                                    Console.WriteLine("\n\n\n\t\rLicense file found in : " + FileList[0]);
                                    File.Copy(FileList[0], "LIC.license", true);
                                    Console.WriteLine("\n\t\rContent of license file : " + File.ReadAllText("LIC.license"));
                                    File.Delete("LIC.license");
                                }
                            }
                        }
                    }
                }
                Console.ReadKey();
