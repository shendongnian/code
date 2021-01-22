        public static void AddOrUpdateResource(string key, string value)
        {
            var resx = new List<DictionaryEntry>();
            using (var reader = new ResXResourceReader(resourceFilepath))
            {
                resx = reader.Cast<DictionaryEntry>().ToList();
                var existingResource = resx.Where(r => r.Key.ToString() == key).FirstOrDefault();
                if (existingResource.Key == null && existingResource.Value == null) // NEW!
                {
                    resx.Add(new DictionaryEntry() { Key = key, Value = value });
                }
                else // MODIFIED RESOURCE!
                {
                    var modifiedResx = new DictionaryEntry() 
                        { Key = existingResource.Key, Value = value };
                    resx.Remove(existingResource);  // REMOVING RESOURCE!
                    resx.Add(modifiedResx);  // AND THEN ADDING RESOURCE!
                }
            }
            using (var writer = new ResXResourceWriter(ResxPathEn))
            {
                resx.ForEach(r =>
                            {
                                // Again Adding all resource to generate with final items
                                writer.AddResource(r.Key.ToString(), r.Value.ToString());
                            });
                writer.Generate();
            }
        }
