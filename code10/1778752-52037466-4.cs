    public class SearchTypeAttribute : Attribute
    {
        public SearchTypeAttribute(Type type)
        {
            this.SType = type;
            this.SItems = Enum.GetValues(type);
        }
    
    }
