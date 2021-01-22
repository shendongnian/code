    class PropertyAType
    {
       public PropertyBType PropertyB {get; set; }
       
       public PropertyBType GetPropertyBOrDefault()
       {
           return PropertyB != null ? PropertyB : defaultValue;
       }
    }
