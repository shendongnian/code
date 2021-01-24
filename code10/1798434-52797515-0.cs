    public class Data
    {
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
    public class Category
    {
        [JsonIgnore]
        public bool HasNameOnly
        {
            get
            {
                return !string.IsNullOrEmpty(Name)
                       && !Mandatory.HasValue
                       && (Fields == null || !Fields.Any());
            }
        }
        public string Name { get; set; }
        public bool? Mandatory { get; set; }
        public List<Field> Fields { get; set; }
    }
    public class Field
    {
        public string Name { get; set; }
    }
