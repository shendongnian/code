        public ObjectOfMyFile ParseFile(string fileContent)
        {
            ObjectOfMyFile objectOfMyFile = new ObjectOfMyFile();
            string[] contentLines = fileContent.Split(new[] { Environment.NewLine },
                                                      StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < contentLines.Length; i++)
            {
                string contentLine = contentLines[i];
                if (contentLine.StartsWith("FMS No", StringComparison.OrdinalIgnoreCase))
                {
                    string[] fmsNo = SplitByColon(contentLine);
                    if (fmsNo.Length == 2)
                    {
                        objectOfMyFile.Longitudes.Add(fmsNo[1].Trim());
                    }
                    continue;
                }
                if (contentLine.IndexOf("WGS84 Longitude", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    string[] longitudeKeyValue = SplitByColon(contentLine);
                    if (longitudeKeyValue.Length == 2)
                    {
                        objectOfMyFile.Longitudes.Add(longitudeKeyValue[1].Trim());
                    }
                    continue;
                }
            }
            return objectOfMyFile;
        }
        public string[] SplitByColon(string valueToSplit)
        {
            return valueToSplit.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
        }
        public class ObjectOfMyFile
        {
            public ObjectOfMyFile()
            {
                Longitudes = new List<string>();
                FmsNos = new List<string>();
            }
            public List<string> Longitudes { get; private set; }
            public List<string> FmsNos { get; private set; }
            // Etc...
        }
    }
