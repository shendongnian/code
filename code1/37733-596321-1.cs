         public bool IsValid()
         {
             mResults = new ValidationResults();
             Validate(mResults);
            
             return mResults.IsValid();
         }
        
         [SelfValidation()]
         public virtual void Validate(ValidationResults results)
         {
             if (!object.ReferenceEquals(this.GetType(), typeof(BusinessBase<T>))) {
                 Validator validator = ValidationFactory.CreateValidator(this.GetType());
                 results.AddAllResults(validator.Validate(this));
             }
             //before we return the bool value, if we have any validation results map them into the
             //broken rules property so the parent class can display them to the end user
             if (!results.IsValid()) {
                 mBrokenRules = new List<BrokenRule>();
                 foreach (Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResult result in results) {
                     mRule = new BrokenRule();
                     mRule.Message = result.Message;
                     mRule.PropertyName = result.Key.ToString();
                     mBrokenRules.Add(mRule);
                 }
             }
         }
