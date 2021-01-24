    public class ViewModel : INotifyDataErrorInfo
    {
        // A place to store all error messages for all properties.
        private IDictionary<string, List<string>> propertyErrors = new Dictionary<string, List<string>>();
        public string Preis
        {
            get { return _preis; }
            set
            {
                // Only update if the value has actually changed.
                if (!string.Equals(_preis, value, StringComparison.Ordinal))
                {
                    _preis = value;
                    Changed();
                    this.Validate();
                }
            }
        }
        // The event to raise when the error state changes.
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;     
        // A method of getting all errors for the given known property.
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (propertyName != null)
            {
                if (propertyErrors.TryGetValue(propertyName, out var errors))
                {
                    return errors;
                }
            }
            return null;
        }
        // Whether there are any errors on the ViewModel
        public bool HasErrors
        {
            get
            {    
                return propertyErrors.Values.Any(r =>r.Any());
            }
        }
        private void Validate()
        {
            // 1. HERE YOU CAN CHECK WHETHER Preis IS VALID AND ANY OTHER PROPERTIES
            // 2. Update the 'propertyErrors' dictionary with the errors
            // 3. Raise the ErrorsChanged event.
        }
    }
