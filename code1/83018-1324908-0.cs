    class Filter 
    {
        public string FieldName {get;set;}
        public string FilterString {get;set;}
           
        public bool IsSatisfied(object o)
        { return o.GetType().GetProperty(FieldName).GetValue(o, null) as string == FilterString;
    }
