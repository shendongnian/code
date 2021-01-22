    string attribute;
    [Required]
    public string Attribute
    {
        get { return attribute; }
        set
        {
            string tempValue = value;
            if (!tempValue.StartsWith("System.Reflection."))
            {
                tempValue = "System.Reflection." + tempValue;
            }
            if (!value.EndsWith("Attribute"))
            {
                tempValue += "Attribute";
            }
            attribute = tempValue;
        }
    }
