    public class CustomConfigurationSection : ConfigurationSection {
      public CustomConfigurationSection()
      {
        var reader = XmlReader.Create(<path to my dll.config>);
        reader.ReadToDescendant("CustomConfigurationSection");
        base.DeserializeElement(reader,false);
      }
      // <rest of code>
    }
