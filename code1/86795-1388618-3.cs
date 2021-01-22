    public struct LazyCreate<T> where T : class, new() {
       private T _value;
       public T Value {
          get {
             if (_value == null) {
                _value = new T();
             }
             return _value;
          }
       }
    }
    
    protected LazyCreate<ComplexType> _propertyName;
    public ComplexType PropertyName {
        get {
            return _propertyName.Value;
        }
    }
