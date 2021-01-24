    namespace Custom.Configs
    {
        public class OnePage2CountryReportConfig : ConfigurationSection
        {
            [ConfigurationProperty("", IsDefaultCollection = true)]
            public CountryGroupCollection Members
            {
                get
                {
                    CountryGroupCollection countryGroupCollection = (CountryGroupCollection)base[""];
                    return countryGroupCollection;
                }
            }
        }
    
        public class CountryGroupCollection : ConfigurationElementCollection
        {
            public CountryGroupCollection()
            {
                CountryGroupElement details = (CountryGroupElement)CreateNewElement();
                if (details.Name != "")
                {
                    Add(details);
                }
            }
    
            public override ConfigurationElementCollectionType CollectionType
            {
                get
                {
                    return ConfigurationElementCollectionType.BasicMap;
                }
            }
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new CountryGroupElement();
            }
    
            protected override Object GetElementKey(ConfigurationElement element)
            {
                return ((CountryGroupElement)element).Name;
            }
    
            public CountryGroupElement this[int index]
            {
                get
                {
                    return (CountryGroupElement)BaseGet(index);
                }
                set
                {
                    if (BaseGet(index) != null)
                    {
                        BaseRemoveAt(index);
                    }
                    BaseAdd(index, value);
                }
            }
    
            new public CountryGroupElement this[string name]
            {
                get
                {
                    return (CountryGroupElement)BaseGet(name);
                }
            }
    
            public int IndexOf(CountryGroupElement details)
            {
                return BaseIndexOf(details);
            }
    
            public void Add(CountryGroupElement details)
            {
                BaseAdd(details);
            }
            protected override void BaseAdd(ConfigurationElement element)
            {
                BaseAdd(element, false);
            }
    
            public void Remove(CountryGroupElement details)
            {
                if (BaseIndexOf(details) >= 0)
                    BaseRemove(details.Name);
            }
    
            public void RemoveAt(int index)
            {
                BaseRemoveAt(index);
            }
    
            public void Remove(string name)
            {
                BaseRemove(name);
            }
    
            public void Clear()
            {
                BaseClear();
            }
    
            protected override string ElementName
            {
                get { return "countryGroup"; }
            }
        }
    
    
        public class CountryCollection : ConfigurationElementCollection
        {
    
            protected override ConfigurationElement CreateNewElement()
            {
                return new Country();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((Country)element).CountryCode;
            }
    
            protected override string ElementName
            {
                get
                {
                    return "country";
                }
            }
    
            protected override bool IsElementName(string elementName)
            {
                return !String.IsNullOrEmpty(elementName) && elementName == "country";
            }
    
            public override ConfigurationElementCollectionType CollectionType
            {
                get
                {
                    return ConfigurationElementCollectionType.BasicMap;
                }
            }
    
            public Country this[int index]
            {
                get
                {
                    return base.BaseGet(index) as Country;
                }
            }
    
            public new Country this[string key]
            {
                get
                {
                    return base.BaseGet(key) as Country;
                }
            }
        }
    
        public class CountryGroupElement : ConfigurationElement
        {
    
            [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
            [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
            public string Name
            {
                get { return (string)this["name"]; }
                set { this["name"] = value; }
            }
    
            [ConfigurationProperty("", IsDefaultCollection = true, IsKey = false, IsRequired = true)]
            public CountryCollection Countries
            {
                get { return base[""] as CountryCollection; }
                set
                {
                    base[""] = value;
                }
            }
    
        }
    
        public class Country : ConfigurationElement
        {
            [ConfigurationProperty("code", IsRequired = true, IsKey = true)]
            [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
            public string CountryCode { get { return (string)this["code"]; } }
        }
    
    }
