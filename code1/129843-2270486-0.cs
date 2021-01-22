    public class Student
    {
        public int Grade { get; set;}
        public string Name { get; set; }
        public string GradePropertyName
        {
            get { return this.PropertyName(s => s.Grade); }
        }
        public string NamePropertyName
        {
            get { return this.PropertyName(s => s.Name); }
        }
    }
    public static class Helper
    {
        public static string PropertyName<T, TProperty>(this T instance, Expression<Func<T, TProperty>> expression)
        {
            var property = expression.Body as MemberExpression;
            if (property != null)
            {
                var info = property.Member as PropertyInfo;
                if (info != null)
                {
                    return info.Name;
                }
            }
            throw new ArgumentException("Expression is not a property");
        }
    }
