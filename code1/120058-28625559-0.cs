    private void Deserialize()
        {
            try
            {
                var f_fileStream = File.OpenRead(@"dictionarySerialized.xml");
                var f_binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                myDictionary = (Dictionary<string, myClass>)f_binaryFormatter.Deserialize(f_fileStream);
                f_fileStream.Close();
            }
            catch (Exception ex)
            {
                ;
            }
        }
        private void Serialize()
        {
            try
            {
                var f_fileStream = new FileStream(@"dictionarySerialized.xml", FileMode.Create, FileAccess.Write);
                var f_binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                f_binaryFormatter.Serialize(f_fileStream, myDictionary);
                f_fileStream.Close();
            }
            catch (Exception ex)
            {
                ;
            }
        }
