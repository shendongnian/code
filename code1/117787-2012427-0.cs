    [XmlRoot("aa")]
    public class aa
    {
      [XmlElement("bb")]
      public bb[] bbs;
    }
    
    public class bb
    {
      [XmlElement("name")]
      public string Name;
    }
