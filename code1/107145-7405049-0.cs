    public class MySection : ConfigurationSection
    {
        [ConfigurationProperty("MyStrings")]
        [TypeConverter(typeof(CommaDelimitedStringCollectionConverter))]
        public CommaDelimitedStringCollection MyStrings
        {
            get { return (CommaDelimitedStringCollection)base["MyStrings"]; }
        }
    }
 
