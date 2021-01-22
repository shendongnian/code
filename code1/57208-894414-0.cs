    public static User Restore()
    {
      if (!File.Exists("data.xml"))
        throw new FileNotFoundException("data.xml");
    
      XmlReader xr = XmlReader.Create("data.xml");
      XmlSerializer serializer = new XmlSerializer(typeof(User));
      var user = (User)serializer.Deserialize(xr);
      xr.Close();
      return user;
    }
