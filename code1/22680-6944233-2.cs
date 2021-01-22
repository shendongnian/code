    namespace Web.Extensions.ValidationAttributes
    {
 
        public class DisplayLabelAttribute :System.ComponentModel.DisplayNameAttribute
        {
            private readonly string _propertyLabel;
     
            public DisplayLabelAttribute(string propertyLabel)
            {
                _propertyLabel = propertyLabel;
            }
    
            public override string DisplayName
            {
                get
                {
                    return _propertyLabel;
                }
            }
        }
    }
