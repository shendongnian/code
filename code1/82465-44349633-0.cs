      public class ObservableByTracking<T> : IObservable<T>
      {
        private readonly Dictionary<string, ObservablePropertyContext> _expando;
        private bool _isDirty;
        
        public ObservableByTracking()
        {
          _expando = new Dictionary<string, ObservablePropertyContext>();
    
          var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
          foreach (var property in properties)
          {
            var valueContext = new ObservablePropertyContext(property.Name, property.PropertyType)
            {
              Value = GetDefault(property.PropertyType)
            };
    
            _expando[BuildKey(valueContext)] = valueContext;
          }
        }
    
        protected void SetValue<T>(Expression<Func<T>> expression, T value)
        {
          var keyContext = GetKeyContext(expression);
          var key = BuildKey(keyContext.PropertyName, keyContext.PropertyType);
    
          if (!_expando.ContainsKey(key))
          {
            throw new Exception($"Object doesn't contain {keyContext.PropertyName} property.");
          }
    
          var originalValue = (T)_expando[key].Value;
          if (EqualityComparer<T>.Default.Equals(originalValue, value))
          {
            return;
          }
    
          _expando[key].Value = value;
          _isDirty = true;
        }
    
        protected T GetValue<T>(Expression<Func<T>> expression)
        {
          var keyContext = GetKeyContext(expression);
          var key = BuildKey(keyContext.PropertyName, keyContext.PropertyType);
    
          if (!_expando.ContainsKey(key))
          {
            throw new Exception($"Object doesn't contain {keyContext.PropertyName} property.");
          }
    
          var value = _expando[key].Value;
          return (T)value;
        }
    
        private KeyContext GetKeyContext<T>(Expression<Func<T>> expression)
        {
          var castedExpression = expression.Body as MemberExpression;
          if (castedExpression == null)
          {
            throw new Exception($"Invalid expression.");
          }
    
          var parameterName = castedExpression.Member.Name;
    
          var propertyInfo = castedExpression.Member as PropertyInfo;
          if (propertyInfo == null)
          {
            throw new Exception($"Invalid expression.");
          }
    
          return new KeyContext {PropertyType = propertyInfo.PropertyType, PropertyName = parameterName};
        }
    
        private static string BuildKey(ObservablePropertyContext observablePropertyContext)
        {
          return $"{observablePropertyContext.Type.Name}.{observablePropertyContext.Name}";
        }
    
        private static string BuildKey(string parameterName, Type type)
        {
          return $"{type.Name}.{parameterName}";
        }
        
        private static object GetDefault(Type type)
        {
          if (type.IsValueType)
          {
            return Activator.CreateInstance(type);
          }
          return null;
        }
        
        public bool IsDirty()
        {
          return _isDirty;
        }
    
        public void SetPristine()
        {
          _isDirty = false;
        }
    
        private class KeyContext
        {
          public string PropertyName { get; set; }
          public Type PropertyType { get; set; }
        }
      }
      public interface IObservable<T>
      {
        bool IsDirty();
        void SetPristine();
      }
