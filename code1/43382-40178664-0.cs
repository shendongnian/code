        public static bool AddToResourceFile(string key, string value, string comment, string path)
        {
            using (ResXResourceWriter resourceWriter = new ResXResourceWriter(path))
            {
                //Get existing resources
                using (ResXResourceReader reader = new ResXResourceReader(path) { UseResXDataNodes = true })
                {
                    foreach (DictionaryEntry resEntry in reader)
                    {
                        ResXDataNode node = resEntry.Value as ResXDataNode;
                        if (node == null) continue;
                        if (string.CompareOrdinal(key, node.Name) == 0)
                        {
                            // Keep resources untouched. Alternativly modify this resource.
                            return false;
                        }
                        resourceWriter.AddResource(node);
                    }
                }
                //Add new data (at the end of the file):
                resourceWriter.AddResource(new ResXDataNode(key, value) { Comment = comment });
                //Write to file
                resourceWriter.Generate();
            }
            return true;
        }
