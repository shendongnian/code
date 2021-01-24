    static void getSubDirectoryList3(string workingDirectory)
            {
                string[] directories = 
                Directory.GetDirectories(@"F:\Apps\SoftwareAndApplications\").Filter;
        
                foreach (string directory in directories)
                {
                    DirectoryInfo dir = new DirectoryInfo(directory);
                    if(dir.CreationTime.Month == DateTime.Now.Month - 1)
                        Console.WriteLine(directory);
                }
            }
