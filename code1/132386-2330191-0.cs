    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication1
    {
        public class DatabaseFieldAttribute : Attribute
        {
            public string Name { get; set; }
    
            public DatabaseFieldAttribute(string name)
            {
                this.Name = name;
            }
        }
    
        public static class MyClassExtensions
        {
            public static string DbField<T>(this T obj, Expression<Func<T, string>> value)
            {
                var memberExpression = value.Body as MemberExpression;
                var attr = memberExpression.Member.GetCustomAttributes(typeof(DatabaseFieldAttribute), true);
                return ((DatabaseFieldAttribute)attr[0]).Name;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var p = new Program();
                Console.WriteLine("DbField = '{0}'", p.DbField(v => v.Title));
    
            }
            [DatabaseField("title")]
            public string Title { get; set; }
    
        }
    }
