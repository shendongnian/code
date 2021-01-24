    public class CustomVertex : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public CustomVertex()
        {
          this.errors = new Dictionary<string, List<string>>();
          this.validationRules = new Dictionary<string, List<ValidationRule>>();
          this.validationRules.Add(nameof(this.X), new List<ValidationRule>() {new DoubleValidationRule()});
          this.validationRules.Add(nameof(this.Y), new List<ValidationRule>() {new DoubleValidationRule()});
        }
   
        public bool ValidateProperty(object value, [CallerMemberName] string propertyName = null)  
        {  
            lock (this.syncLock)  
            {  
                if (!this.validationRules.TryGetValue(propertyName, out ValidationRule validationRule))
                {
                  return;
                }  
               
                // Clear previous errors from tested property  
                if (this.errors.ContainsKey(propertyName))  
                {
                   this.errors.Remove(propertyName);  
                   OnErrorsChanged(propertyName);  
                }
                ValidationResult result = validationRule.Validate(value, CultuteInfo.CurrentCulture);
                if (result.IsValid)
                {
                  return;
                }
                AddError(propertyName, result.ErrorContent, false);
            }  
        }   
   
        // Adds the specified error to the errors collection if it is not 
        // already present, inserting it in the first position if isWarning is 
        // false. Raises the ErrorsChanged event if the collection changes. 
        public void AddError(string propertyName, string error, bool isWarning)
        {
            if (!this.errors.ContainsKey(propertyName))
            {
               this.errors[propertyName] = new List<string>();
            }
            if (!this.errors[propertyName].Contains(error))
            {
                if (isWarning) 
                {
                  this.errors[propertyName].Add(error);
                }
                else 
                {
                  this.errors[propertyName].Insert(0, error);
                }
                RaiseErrorsChanged(propertyName);
            }
        }
        // Removes the specified error from the errors collection if it is
        // present. Raises the ErrorsChanged event if the collection changes.
        public void RemoveError(string propertyName, string error)
        {
            if (this.errors.ContainsKey(propertyName) &&
                this.errors[propertyName].Contains(error))
            {
                this.errors[propertyName].Remove(error);
                if (this.errors[propertyName].Count == 0)
                {
                  this.errors.Remove(propertyName);
                }
                RaiseErrorsChanged(propertyName);
            }
        }
        #region INotifyDataErrorInfo Members
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName) || 
                !this.errors.ContainsKey(propertyName)) return null;
            return this.errors[propertyName];
        }
        public bool HasErrors
        {
            get { return errors.Count > 0; }
        }
        #endregion
   
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private double x;
        public double X 
        { 
          get => x; 
          set 
          { 
            if (ValidateProperty(value))
            {
              this.x = value; 
              OnPropertyChanged();
            }
          }
        }
    
        private double y;
        public double Y 
        { 
          get => this.y; 
          set 
          { 
            if (ValidateProperty(value))
            {
              this.y = value; 
              OnPropertyChanged();
            }
          }
        }
        private Dictionary<String, List<String>> errors;
        // The ValidationRules for each property
        private Dictionary<String, List<ValidationRule>> validationRules;
        private object syncLock = new object();
    }
    
