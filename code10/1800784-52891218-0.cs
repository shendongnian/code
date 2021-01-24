    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [XmlInclude(typeof(CustomFieldCollection))]
    [XmlInclude(typeof(CustomField))]
    [XmlInclude(typeof(CustomField[]))]
    public class Service : System.Web.Services.WebService
    {
    
        public Service()
        {
        }
    
        [WebMethod]
        public CustomFieldCollection GetFieldsCollection()
        {
            CustomFieldCollection collection = new CustomFieldCollection();
            collection["fieldA"] = 1;
            collection["fieldB"] = true;
            collection["fieldC"] = DateTime.Now;
            collection["fieldD"] = "hello";
            return collection;
        }
    }
    public class CustomFieldCollection
    {
        private List<CustomField> fields = new List<CustomField>();
    
        public object this[String name]
        {
            get { return fields.FirstOrDefault(x => x.Name == name); }
            set
            {
                if (!fields.Exists(x => x.Name == name))
                {
                    fields.Add(new CustomField(name, value));
                }
                else
                {
                    this[name] = value;
                }
            }
        }
    
        public CustomField[] Collection
        {
            get { return fields.ToArray(); }
            set { }
        }
    }
    
    
    public class CustomField
    {
        public string Name { get; set; }
        public object Value { get; set; }
    
        public CustomField()
        {
        }
    
        public CustomField(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
