    public interface INotifyDataErrorInfo 
    {
        // Returns True if the object has at least one property-level or top-level error. 
        bool HasErrors { get; }
    
        // Returns the current set of property-level errors for the provided property name, or
        // the current top-level errors if the argument is null or empty. 
        IEnumerable GetErrors(string propertyName);
    
        // Raised when the set of errors for a particular property has changed, or when the 
        // top-level errors have changed. 
        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
