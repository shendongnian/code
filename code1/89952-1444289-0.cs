    public class SectionHandler : ConfigurationSection
    {
      [ConfigurationProperty("foo")]
      public MyObject ConfigurationValue
      {
        get { return (MyObject) this["foo"]; }
      }
    }
