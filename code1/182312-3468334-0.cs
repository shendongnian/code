    class PropertyAType
    {
       public int PropertyB {get; set; }
       
       public int GetPropertyBOrDefault()
       {
           return PropertyB != null ? PropertyB : defaultInt;
       }
    }
