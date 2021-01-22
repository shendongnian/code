    public class MyViewModel
    {
        // Properties to be serialized
        public string MyViewModelProperty1 = "";
        public string MyViewModelProperty2 = "";
        // Save to file.
        public virtual bool Save(string viewmodelFilePath)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(viewmodelFilePath));
                StreamWriter write = new StreamWriter(viewmodelFilePath);
                XmlSerializer xml = new XmlSerializer(GetType());
                xml.Serialize(write, this);
                write.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
        // Load from file.
        public static object Load(Type type, string viewmodelFilePath)
        {
            StreamReader reader;
            object settings;
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                reader = new StreamReader(viewmodelFilePath);
                viewmodel = xml.Deserialize(reader);
                reader.Close();
            }
            catch
            {
                viewmodel = 
                    type.GetConstructor(System.Type.EmptyTypes).Invoke(null);
            }
            return viewmodel;
        }
    }
