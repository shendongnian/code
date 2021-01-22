    [XmlIgnore()]   
    public Dictionary<string, DataProperty> Properties
    {   
        set { properties = value; }   
        get { return properties ; }   
    }
    [XmlArray("Stuff")]   
    [XmlArrayItem("StuffLine", Type=typeof(DictionaryEntry))]   
    public DictionaryEntry[] PropertiesList
    {   
        get  
        {   
            //Make an array of DictionaryEntries to return   
            DictionaryEntry[] ret=new DictionaryEntry[Properties.Count];   
            int i=0;   
            DictionaryEntry de;   
            //Iterate through Stuff to load items into the array.   
            foreach (KeyValuePair<string, DataProperty> props in Properties)   
            {   
                de = new DictionaryEntry();   
                de.Key = props.Key;   
                de.Value = props.Value;   
                ret[i]=de;   
                i++;   
            }   
            return ret;   
        }   
        set  
        {   
            Properties.Clear();   
            for (int i=0; i<value.Length; i++)   
            {   
                Properties.Add((string)value[i].Key, (DataProperty)value[i].Value);   
            }   
        }   
    }  
