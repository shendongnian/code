    static void Main(string[] args)
            {
                Dictionary<int, string[]> filesData = new Dictionary<int, string[]>();
                importFiles(filesData);
    
    
            }
    
            static void importFiles(Dictionary<int, string[]> filesData)
            {
                var path = @"export/file.txt";
    
    
                if (File.Exists(path))
                {
                    string[] fileLines = File.ReadAllLines(path);
    
                    for (int i = 0; i < fileLines.Length; i++)
                    {
                        string line = fileLines[i];
                        string[] split = line.Split(';');
    
                        for (int j = 0; j < split.Length; j++)
                        {
                            split[j] = split[j].Trim();
                        }
                        int index = filesData.Count == 0 ? 0: filesData.Keys.Max(); 
                        filesData.Add(index + 1, split);
    
                    }
                }
            }
