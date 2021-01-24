    public class SchoolConfig : ConfigurationSection
    {
        public static SchoolConfig Settings { get; } = (SchoolConfig)ConfigurationManager.GetSection("school");
        [ConfigurationProperty("name")]
        public string Name { get { return (string)base["name"]; } }
        [ConfigurationProperty("address")]
        public AddressElement Address { get { return (AddressElement)base["address"]; } }
        [ConfigurationProperty("courses")]
        public CourseElementCollection Courses { get { return base["courses"] as CourseElementCollection; } }
    }
