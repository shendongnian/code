                string[] drives = System.IO.Directory.GetLogicalDrives();
                foreach (string str in drives) 
                {
                    System.Console.WriteLine(str);
                }
