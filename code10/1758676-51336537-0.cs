    public class DepartmentsConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("departments", IsRequired = false, IsDefaultCollection = true)]
        public DepartmentItemCollection Departments
        {
            get
            {
                var departments = this["departments"] as DepartmentItemCollection;
                return departments;
            }
            set
            {
                this["departments"] = value;
            }
        }
    }
    [ConfigurationCollection(typeof(DepartmentItemCollection), AddItemName = "department")]
    public class DepartmentItemCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Department();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Department)element).Name;
        }
    }
    public class Department : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = false, IsKey = true)]
        public int Id
        {
            get
            {
                return (int)(this["id"]);
            }
            set
            {
                this["id"] = value;
            }
        }
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get
            {
                return (string)(this["name"]);
            }
            set
            {
                this["name"] = value;
            }
        }
        [ConfigurationProperty("products", IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public ProductCollection Products
        {
            get
            {
                return (ProductCollection)this["products"];
            }
            set
            {
                this["products"] = value;
            }
        }
    }
    [ConfigurationCollection(typeof(ProductCollection), AddItemName = "product")]
    public class ProductCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Product();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Product)element).Name;
        }
    }
    public class Product : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get
            {
                return (string)(this["name"]);
            }
            set
            {
                this["name"] = value;
            }
        }
        [ConfigurationProperty("price", IsRequired = false)]
        public decimal Price
        {
            get
            {
                return (decimal)(this["price"]);
            }
            set
            {
                this["price"] = value;
            }
        }
        [ConfigurationProperty("", IsRequired = false, IsKey = false, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(KeyValueConfigurationCollection), AddItemName = "add")]
        public KeyValueConfigurationCollection Items
        {
            get
            {
                var items = base[""] as KeyValueConfigurationCollection;
                return items;
            }
            set
            {
                base[""] = value;
            }
        }
    }
