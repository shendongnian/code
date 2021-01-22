    public void Save(Configuration config, string fileName)
	{
       XmlSerializer xml = new XmlSerializer(typeof(Configuration));
       using (StreamWriter sw = new StreamWriter(fileName))
       {
           xml.Serialize(sw, config);
       }
    }
    public Configuration Load(string fileName)
	{
       XmlSerializer xml = new XmlSerializer(typeof(Configuration));
       using (StreamReader sr = new StreamReader(fileName))
       {
           return (Configuration)xml.Deserialize(sr);
       }
    }
