    public class MyCustomerAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Dictionary<string, ModelValidBase> _registerTable = new Dictionary<string, ModelValidBase>();
            _registerTable.Add("Vehicule", new VehiculeContext(validationContext,value));
            _registerTable.Add("Color", new ColorContext(validationContext, value));
            Type testType = validationContext.ObjectInstance.GetType();
            ModelValidBase excuteValid;
            if (!_registerTable.TryGetValue(testType.Name, out excuteValid))
            {
                //return a result when you didn't get context from the register table.
            }
            return excuteValid.Dosomthing();
        }
    }
