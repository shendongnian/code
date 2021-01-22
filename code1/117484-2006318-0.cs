    List<string> logicalDrives = Directory.GetLogicalDrives().ToList();
                List<string> result = new List<string>();
                foreach (string drive in logicalDrives)
                {
                    Console.WriteLine("Searching " + drive);
                    DriveInfo di = new DriveInfo(drive);
                    if(di.IsReady)
                        result = Directory.GetFiles(drive, "tnsnames.ora", SearchOption.AllDirectories).ToList();
                    if (0 < result.Count) return;
                }
                foreach (string file in result) { Console.WriteLine(result); }
