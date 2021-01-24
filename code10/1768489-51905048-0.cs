        public JObject root = null;
        public void ReadLanguage()
        {
            try
            {
                // Reads file contents into FileStream
                FileStream stream = File.OpenRead(languagesPath + filename + ".yml");
                // Converts the FileStream into a YAML Dictionary object
                var deserializer = new DeserializerBuilder().Build();
                var yamlObject = deserializer.Deserialize(new StreamReader(stream));
                // Converts the YAML Dictionary into JSON String
                var serializer = new SerializerBuilder()
                    .JsonCompatible()
                    .Build();
                string jsonString = serializer.Serialize(yamlObject);
                root = JObject.Parse(jsonString);
                plugin.Info("Successfully loaded language file.");
            }
            catch (Exception e)
            {
                if (e is DirectoryNotFoundException)
                {
                    plugin.Error("Language directory not found.");
                }
                else if (e is UnauthorizedAccessException)
                {
                    plugin.Error("Language file access denied.");
                }
                else if (e is FileNotFoundException)
                {
                    plugin.Error("'" + filename + ".yml' was not found.");
                }
                else if (e is JsonReaderException || e is YamlException)
                {
                    plugin.Error("'" + filename + ".yml' formatting error.");
                }
                plugin.Error("Error reading language file '" + filename + ".yml'. Deactivating plugin...");
                plugin.Debug(e.ToString());
                plugin.Disable();
            }
        }
   
