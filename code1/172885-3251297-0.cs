    [XmlAttribute("Age")]
    public string Age
    {
        get 
        { 
            if (this.age.HasValue)
                return this.age.Value.ToString(); 
            else
                return null;
        }
        set 
        { 
            if (value != null)
                this.age = int.Parse(value);
            else
                this.age = null;
        }
    }
