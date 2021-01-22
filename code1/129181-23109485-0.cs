    public interface IValuePointer<T>
    {
    	T Value { get; set; }
    }
    public class ValuePointer<TParent, TType> : IValuePointer<TType>
    {
        private readonly TParent _instance;
        private readonly Func<TParent, TType> _propertyExpression;
        private readonly PropertyInfo _propInfo;
        private readonly FieldInfo _fieldInfo;
    
        public ValuePointer(TParent instance, 
                            Expression<Func<TParent, TType>> propertyExpression)
        {
            _instance = instance;
            _propertyExpression = propertyExpression.Compile();
            _propInfo = ((MemberExpression)(propertyExpression).Body).Member as PropertyInfo;
            _fieldInfo = ((MemberExpression)(propertyExpression).Body).Member as FieldInfo;
        }
    	
    	public TType Value
        {
            get { return _propertyExpression.Invoke(_instance); }
            set
            {
                if (_fieldInfo != null)
                {
                    _fieldInfo.SetValue(_instance, value);
                    return;
                }
                _propInfo.SetValue(_instance, value, null);
            }
        }
    }
