        public void DoValidation()
        {
            var toValidate = new ValidateMe()
            {
                Enable = true,
                Prop1 = 1,
                Prop2 = 2
            };
            bool validateAllProperties = false;
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
                toValidate,
                new ValidationContext(toValidate, null, null),
                results,
                validateAllProperties);
        }
