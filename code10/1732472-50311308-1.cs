     public string[] getBlocks(string path)
            {
                string[] blocks = File.ReadAllText(path).Split(new string[] { "#========================================================" }, StringSplitOptions.None);
                return blocks;
            }
            public Dictionary<string, string[]> getValues(string block)
            {
                Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
                var foos = new List<string>(Regex.Split(block, "\t"));
                foos.RemoveAt(0);
                string[] values = Regex.Split(String.Join("\t", foos.ToArray()), "\r");
                values = values.Take(values.Count() - 1).ToArray();
                foreach (string value in values)
                {
                    string[] fieldName = Regex.Split(value, "\t");
                    fieldName = fieldName.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    var newList = new List<string>(fieldName);
                    if(newList.Count >= 1)
                    {
                        newList.RemoveAt(0);
                        string[] valueList = newList.ToArray();
                        dictionary.Add(fieldName[0], valueList);
                    }
                    else
                    {
                    }
    
                }
                return dictionary;
    }
