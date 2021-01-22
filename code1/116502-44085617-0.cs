    using System.Linq.Expressions;
    namespace ConsoleApp1
    {
        public static class Helper
        {
            public static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression)
            {
                var member = propertyExpression.Body as MemberExpression;
                if (member != null)
                    return member.Member.Name;
                else
                    throw new ArgumentNullException("Property name not found.");
            }
            public static string GetPropertyName<T>(this T obj, Expression<Func<T, object>> propertyExpression)
            {
                return GetPropertyName(propertyExpression);
            }
        }
        public class SampleClass
        {
            public string MyProperty { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Property name of type
                Console.WriteLine(Helper.GetPropertyName<SampleClass>(x => x.MyProperty));
                // Property name of instance
                var someObject = new SampleClass();
                Console.WriteLine(someObject.GetPropertyName(x => x.MyProperty));
                Console.ReadKey();
            }
        }
    }
