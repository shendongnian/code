    public class EntityKeyResolver<T, TProperty> : ValueResolver<T, EntityKey> where T : class
    {
        private Expression<Func<T, TProperty>> _propertyExpression;
        private string _qualifiedEntitySetName;
        private string _keyName;
    
        public EntityKeyResolver(string qualifiedEntitySetName, string keyName, Expression<Func<T, TProperty>> propertyExpression)
        {
            _qualifiedEntitySetName = qualifiedEntitySetName;
            _keyName = keyName;
            _propertyExpression = propertyExpression;
        }
    
        protected override EntityKey ResolveCore(T source)
        {
            return new EntityKey(_qualifiedEntitySetName, _keyName, ExpressionHelper.GetValue(_propertyExpression));
        }
    }
