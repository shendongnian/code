    public class model1
    {
         public DateTime param1 { get; set; }
         [CustomAttribute (nameof(param1))]
         public string param2 { get; set; }
    }
    public class CustomAttribute : ValidationAttribute
    {
        private readonly string _propertyName;
        public CustomAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }
    }
