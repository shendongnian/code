    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace ConsoleTest
    {
        public class Values
        {
            public int X { get; set; }
            public int Y { get; set; }
    
            public override string ToString()
            {
                return String.Format("[ X={0} Y={1} ]", X, Y);
            }
        }
    
        class Program
        {
            static void Main()
            {
                var values = new Values {X = 1, Y = 1};
    
                // pass parameter to be incremented as linq expression
                IncrementValue(values, v => v.X);
                IncrementValue(values, v => v.X);
                IncrementValue(values, v => v.Y);
    
                // Output is: [ X=3 Y=2 ]
                Console.Write(values);
            }
    
            private static void IncrementValue<T>(T obj, Expression<Func<T,int>> property)
            {
                var memberExpression = (MemberExpression)property.Body;
                var propertyInfo = (PropertyInfo)memberExpression.Member;
                // read value with reflection
                var value = (int)propertyInfo.GetValue(obj, null);
                // set value with reflection
                propertyInfo.SetValue(obj, ++value, null);
            }
        }
    }
