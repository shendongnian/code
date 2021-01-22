    public class GetterSetter<EntityType,propType>
    {
        private readonly Func<EntityType, propType> getter;
        private readonly Action<EntityType, propType> setter;
        private readonly string propertyName;
        private readonly Expression<Func<EntityType, propType>> propertyNameExpression;
        public EntityType Entity { get; set; }
        public GetterSetter(EntityType entity, Expression<Func<EntityType, propType>> property_NameExpression)
        {
            Entity = entity;
            propertyName = GetPropertyName(property_NameExpression);
            propertyNameExpression = property_NameExpression;
            //Create Getter
            getter = propertyNameExpression.Compile();
            // Create Setter()
            MethodInfo method = typeof (EntityType).GetProperty(propertyName).GetSetMethod();
            setter = (Action<EntityType, propType>)
                     Delegate.CreateDelegate(typeof(Action<EntityType, propType>), method);
        }
        public propType Value
        {
            get
            {
                return getter(Entity);
            }
            set
            {
                setter(Entity, value);
            }
        }
        protected string GetPropertyName(LambdaExpression _propertyNameExpression)
        {
            var lambda = _propertyNameExpression as LambdaExpression;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = lambda.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambda.Body as MemberExpression;
            }
            var propertyInfo = memberExpression.Member as PropertyInfo;
            return propertyInfo.Name;
        }
