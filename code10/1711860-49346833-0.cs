    string[] lines = File.ReadAllLines(@"D:\Professionals\POC\linQ\linQ\DataFile.txt", Encoding.UTF8);
            if (lines.Count() > 0)
            {
                Dictionary<string, int> listIndex = lines.ToDictionary(
                                                                       x => x.Split('=')[0].Trim(), 
                                                                       x => (x.Contains("$") ? Convert.ToInt32(x.Split('=')[1].Replace("$", "")) : 0)
                                                                       );
                listIndex = listIndex.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                if (listIndex != null && listIndex.Count > 0)
                {
                    //---your code 
                }
            }
            
