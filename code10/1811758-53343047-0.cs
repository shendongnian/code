        { // your code(now working as intended)
            // Directory Info
            string path = @"C:\Path";
            DirectoryInfo DFolder = new DirectoryInfo(path);
            string DFPath = DFolder.Name;
            // Get Desired Directories
            List<string> directoryFilter = new List<string> { "images", "videos", "RAW" };
            List<DirectoryInfo> directoryList = DFolder.GetDirectories("*", SearchOption.AllDirectories).Where(x => directoryFilter.Contains(x.Name.ToLower())).ToList();
            string dpath = directoryList.ToString();
            foreach (DirectoryInfo record in directoryList)
            {
                foreach (FileInfo file in record.GetFiles(@"*", SearchOption.AllDirectories)) //searches directory record and its subdirectories
                {
                    Console.WriteLine(file); 
                }
            }
        }
