    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    class Foo
    {
        public string Bar { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            PropertyInfo prop = PropertyHelper<Foo>.GetProperty(x => x.Bar);
        }
    }
    public static class PropertyHelper<T>
    {
        public static PropertyInfo GetProperty<TValue>(
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
                    return (PropertyInfo)((MemberExpression)body).Member;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
