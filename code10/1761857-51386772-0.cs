      string path = HostingEnvironment.ApplicationPhysicalPath + (some path);
       public void LoadXML()
        {
            if (System.IO.File.Exists(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
                lock (new object())
                {
                    using (TextReader reader = new StreamReader(path))
                    {
                        return (List<int>)(serializer.Deserialize(reader));
                    }
                }
            }
        }
