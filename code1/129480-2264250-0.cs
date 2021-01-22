    [AttributeUsageAttribute(AttributeTargets.Property, AllowMultiple = true)]
    class V : ValidationAttribute {    
        public override bool IsValid(object value) {
            //...        
            if (hasErrors)
                ErrorMessage = errorMsg;
            //...        
        }    
    }
