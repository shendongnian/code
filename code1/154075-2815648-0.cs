    public class MyViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
       private Dictionary<string, string> _Errors = new Dictionary<string, string>();
       public object SomeProperty
       {
          get { return _SomeProperty; }
          set
          {
             if (value != _SomeProperty && !ValidationError("SomeProperty", value))
                _SomeProperty = value;
                OnPropertyChanged("SomeProperty");
             }
          }
       }
       private bool ValidationError(string propertyName, object value)
       {
          // I usually have a Dictionary<string, Func<object, string>> that maps property
          // names to validation functions; the functions return null if the property
          // is valid and an error message if not.  You can embed the validation logic
          // in the property setters, of course, but breaking them out as separate methods
          // eases testing.
          _Errors[propertyName] = _ValidationMethods[propertyName](value);
          OnPropertyChanged("IsValid");
       }
       public bool IsValid
       {
          get { return !(_Errors.Where(x => x.Value != null).Any()));
       }
       public string this[string propertyName]
       {
          get
          {
             return (_Errors.ContainsKey(propertyName))
                ? _Errors[propertyName]
                : null;
          }
       }
    }
