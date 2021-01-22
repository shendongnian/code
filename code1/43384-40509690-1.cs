        public static void UpdateResourceFile(Dictionary<string, string> data, string path)
        {
            Dictionary<string, string> resourceEntries = new Dictionary<string, string>();
            if (File.Exists(path))
            {
                //Get existing resources
                ResXResourceReader reader = new ResXResourceReader(path);
                resourceEntries = reader.Cast<DictionaryEntry>().ToDictionary(d => d.Key.ToString(), d => d.Value?.ToString() ?? "");
                reader.Close();
            }
            //Modify resources here...
            foreach (KeyValuePair<string, string> entry in data)
            {
                if (!resourceEntries.ContainsKey(entry.Key))
                {
                    if (!resourceEntries.ContainsValue(entry.Value))
                    {
                        resourceEntries.Add(entry.Key, entry.Value);
                    }
                }
            }
            string directoryPath = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            //Write the combined resource file
            ResXResourceWriter resourceWriter = new ResXResourceWriter(path);
            foreach (KeyValuePair<string, string> entry in resourceEntries)
            {
                resourceWriter.AddResource(entry.Key, resourceEntries[entry.Key]);
            }
            resourceWriter.Generate();
            resourceWriter.Close();
        }
