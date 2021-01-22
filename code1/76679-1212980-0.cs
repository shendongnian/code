        private void SerializeList(List<Object> Targets, string TargetPath)
        {
            IFormatter Formatter = new BinaryFormatter();
            using (FileStream OutputStream = System.IO.File.Create(TargetPath))
            {
                try
                {
                    Formatter.Serialize(OutputStream, Targets);
                } catch (SerializationException ex) {
                    //(Likely Failed to Mark Type as Serializable)
                    //...
                }
        }
