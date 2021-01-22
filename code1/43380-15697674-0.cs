     public static void UpdateResourceFile(Hashtable data, String path)
        {
            Hashtable resourceEntries = new Hashtable();
            //Get existing resources
            ResXResourceReader reader = new ResXResourceReader(path);
            reader.UseResXDataNodes = true;
            ResXResourceWriter resourceWriter = new ResXResourceWriter(path);
            System.ComponentModel.Design.ITypeResolutionService typeres = null;
            if (reader != null)
            {
                IDictionaryEnumerator id = reader.GetEnumerator();
                foreach (DictionaryEntry d in reader)
                {
                    //Read from file:
                    string val = "";
                    if (d.Value == null)
                        resourceEntries.Add(d.Key.ToString(), "");
                    else
                    {
                        val = ((ResXDataNode)d.Value).GetValue(typeres).ToString();
                        resourceEntries.Add(d.Key.ToString(), val);
                        
                    }
                    //Write (with read to keep xml file order)
                    ResXDataNode dataNode = (ResXDataNode)d.Value;
                    
                    //resourceWriter.AddResource(d.Key.ToString(), val);
                    resourceWriter.AddResource(dataNode);
                }
                reader.Close();
            }
            //Add new data (at the end of the file):
            Hashtable newRes = new Hashtable();
            foreach (String key in data.Keys)
            {
                if (!resourceEntries.ContainsKey(key))
                {
                    String value = data[key].ToString();
                    if (value == null) value = "";
                    resourceWriter.AddResource(key, value);
                }
            }
            //Write to file
            resourceWriter.Generate();
            resourceWriter.Close();
        }
