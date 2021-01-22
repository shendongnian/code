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
                    resourceEntries.Add(entry.Key, entry.Value);
                }
            }
            //Write the combined resource file
            ResXResourceWriter resourceWriter = new ResXResourceWriter(path);
            foreach (string key in resourceEntries.Keys)
            {
                resourceWriter.AddResource(key, resourceEntries[key]);
            }
            resourceWriter.Generate();
            resourceWriter.Close();
        }
