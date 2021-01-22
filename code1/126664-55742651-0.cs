using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Student();
            PrintProperty(a, "Name");
            PrintProperty(a, "Age");
            Console.ReadKey();
        }
        private static void PrintProperty<T>(T a, string propName)
        {
            PrintProperty<T, object>(a, propName);
        }
        private static void PrintProperty<T, TProperty>(T a, string propName)
        {
            ParameterExpression ep = Expression.Parameter(typeof(T), "x");
            MemberExpression em = Expression.Property(ep, typeof(T).GetProperty(propName));
            var el = Expression.Lambda<Func<T, TProperty>>(Expression.Convert(em, typeof(object)), ep);
            Console.WriteLine(GetValue(a, el));
        }
        private static TPorperty GetValue<T, TPorperty>(T v, Expression<Func<T, TPorperty>> expression)
        {
            return expression.Compile().Invoke(v);
        }
        public class Student
        {
            public Student()
            {
                Name = "Albert Einstein";
                Age = 15;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
