    public class MyCustomCongifuration : ConfigurationSection
    {
         [ConfigurationProperty("people", IsDefaultCollection = true)]
         public PersonConfigurationElementCollection People
         {
             get { return (PersonConfigurationElementCollection)this["people"]; }
             set { this["people"] = value; }
         }
    }
