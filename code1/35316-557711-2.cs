    public class PropertyHelper<T>
    {
        public PropertyInfo GetPropertyValue<TValue>(
            Expression<Func<T, TValue>> selector)
        {
            Expression body = selector;
            if (body is LambdaExpression)
            {
                body = ((LambdaExpression)body).Body;
            }
            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return GetValue<TValue>(
                        ((PropertyInfo)((MemberExpression)body).Member).Name);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
    private static readonly PropertyHelper<Xxxx> propertyHelper 
        = new PropertyHelper<Xxxx>();
    public int Foo
    {
        get { return propertyHelper.GetPropertyValue(x => x.Foo); }		
    }
