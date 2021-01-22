    public static class DataBinder
    {
        public static DataBinderBindingSourceContext<TDataSource> BindToObject<TDataSource>(TDataSource dataSource)
        {
            return new DataBinderBindingSourceContext<TDataSource>(dataSource);
        }
    }
    public class DataBinderBindingSourceContext<TDataSource> 
    {
        public readonly object DataSource;
        public DataBinderBindingSourceContext(object dataSource)
        {
            DataSource = dataSource;
        }
        public DataBinderControlContext<TDataSource, TProperty> ObjectProperty<TProperty>(Expression<Func<TDataSource, TProperty>> property)
        {
            return new DataBinderControlContext<TDataSource, TProperty>(this, property);
        }
    }
    public class DataBinderControlContext<TDataSource, TProperty>
    {
        readonly DataBinderBindingSourceContext<TDataSource> BindingSourceContext;
        readonly string ObjectProperty;
        public DataBinderControlContext
            (
                DataBinderBindingSourceContext<TDataSource> bindingSourceContext,
                Expression<Func<TDataSource, TProperty>> objectProperty
            )
        {
            BindingSourceContext = RequireArg.NotNull(bindingSourceContext);
            ObjectProperty = ExpressionHelper.GetPropertyName(objectProperty);
        }
        public DataBinderControlContext<TDataSource, TProperty> Control<TControl>(TControl control, Expression<Func<TControl, TProperty>> property)
            where TControl : Control
        {
            var controlPropertyName = ExpressionHelper.GetPropertyName(property);
            control.DataBindings.Add(controlPropertyName, BindingSourceContext.DataSource, ObjectProperty, true);
            return this;
        }
    }
    public static class ExpressionHelper
    {
        public static string GetPropertyName<TResult>(Expression<Func<TResult>> property)
        {
            return GetMemberNames(((LambdaExpression)property).Body).Skip(1).Join(".");
        }
    
        public static string GetPropertyName<T, TResult>(Expression<Func<T, TResult>> property)
        {
            return GetMemberNames(((LambdaExpression)property).Body).Join(".");
        }
        static IEnumerable<string> GetMemberNames(Expression expression)
        {
            if (expression is ConstantExpression || expression is ParameterExpression)
                yield break;
            var memberExpression = (MemberExpression)expression;
            foreach (var memberName in GetMemberNames(memberExpression.Expression))
                yield return memberName;
            yield return memberExpression.Member.Name;
        }
    }
    public static class StringExtentions
    {
        public static string Join(this IEnumerable<string> values, string separator)
        {
            if (values == null)
                return null;
            return string.Join(separator, values.ToArray());
        }
    }
