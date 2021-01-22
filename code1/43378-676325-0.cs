    public static void UpdateResourceFile(Hashtable data, String path)
        {
            Hashtable resourceEntries = new Hashtable();
    
            //Get existing resources
            ResXResourceReader reader = new ResXResourceReader(path);
            if (reader != null)
            {
                IDictionaryEnumerator id = reader.GetEnumerator();
                foreach (DictionaryEntry d in reader)
                {
                    if (d.Value == null)
                        resourceEntries.Add(d.Key.ToString(), "");
                    else
                        resourceEntries.Add(d.Key.ToString(), d.Value.ToString());
                }
                reader.Close();
            }
    
            //Modify resources here...
            foreach (String key in data.Keys)
            {
                if (!resourceEntries.ContainsKey(key))
                {
                    
                    String value = data[key].ToString();
                    if (value == null) value = "";
    
                    resourceEntries.Add(key, value);
                }
            }
    
            //Write the combined resource file
                ResXResourceWriter resourceWriter = new ResXResourceWriter(path);
    
                foreach (String key in resourceEntries.Keys)
                {
                    resourceWriter.AddResource(key, resourceEntries[key]);
                }
                resourceWriter.Generate();
                resourceWriter.Close();
    
        }
