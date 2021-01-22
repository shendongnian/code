    public class TextFileConfigurationElement : ConfigurationElement
    {
      [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
      public string Name { 
        get { return (string)this["name"]; }
        set { this["name"] = value; }
      }
      
      [ConfigurationProperty("textFilePath")]
      public string TextFilePath {
        get { return (string)this["textFilePath"]; }
        set { this["textFilePath"] = value; }
      }
      
      [ConfigurationProperty("xmlFilePath")]
      public string XmlFilePath {
        get { return (string)this["xmlFilePath"]; }
        set { this["xmlFilePath"] = value; }
      }
    }
    
    [ConfigurationCollection(typeof(TextFileConfigurationElement))]
    public class TextFileConfigurationElementCollection : ConfigurationElementCollection
    {
      protected override void CreateNewElement() {
        return new TextFileConfigurationElement();
      }
      
      protected override object GetElementKey(ConfigurationElement element) {
        return ((TextFileConfigurationElement)element).Name;
      }
    }
    
    public class TextFilesConfigurationSection : ConfigurationSection
    {
      [ConfigurationProperty("files")]
      public TextFileConfigurationElementCollection Files {
        get { return (TextFileConfigurationElementCollection)this["files"]; }
        set { this["files"] = value; }
      }
      
      public static TextFilesConfigurationSection GetInstance() {
        return ConfigurationManager.GetSection("textFiles") as TextFilesConfigurationSection;
      }
    }
    
