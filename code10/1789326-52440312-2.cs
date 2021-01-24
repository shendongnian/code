    public class ColorContext : ModelValidBase
    {
        public ColorContext(ValidationContext v, object p) : base(v, p)
        {
        }
        public override ValidationResult Dosomthing()
        {
            Color vehicule = (Color)_validContext;
            //Do something with db.Color, for exemple
            db.Color.Add(Color);
            return ValidationResult.Success;
        }
    }
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
                // doing didn't get model action
            }
            return excuteValid.Dosomthing();
        }
    }
