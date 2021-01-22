    public class UniqueAttribute : ValidationAttribute
    {        
        public string Identifier { get; set; }
        public override bool IsValid(object value)
        {          
            // Get property value
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            string identifierValue = properties.Find(this.Identifier,     true).GetValue(value).ToString();
        }
    }
