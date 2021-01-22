    public bool ToXmlFile(string fileName)
    {
        if(fileName != "")
        {
           XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
           TextWriter writer = new StreamWriter(fileName);
           serializer.Serialize(writer, this);
           writer.Close();
           return true;
        }
        return false;
    }
