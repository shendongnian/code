    public void RemoveCorruptData()
        {
            string path = @"C:\CSV.txt";
            string newPath = @"C:\new-CSV.txt";
            List<string> lines = new List<string>();
            Regex corrupt = new Regex("£$**");
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!corrupt.IsMatch(line))
                        {
                            lines.Add(line);
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(newpath, false))
                {
                    foreach (String line in lines)
                        writer.WriteLine(line);
                }
            }
        }
