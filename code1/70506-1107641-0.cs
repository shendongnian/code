            public void SerializeToFile<T>(T target, string filename)
            {
                XmlSerializer serializer = new XmlSerializer(typeof (T));
     
                using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(stream, target);
                }
            }
