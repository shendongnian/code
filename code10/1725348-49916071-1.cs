    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    namespace ConsoleApp5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myType = new MyType();
                myType.p = "Some Value";
                var compareMethod = DoWork<MyType>("Some Value", "p");
                var isEqual = compareMethod(myType);
            }
            public static Func<T, bool>  DoWork<T>(object val, string prop)
            {
                //The code below will construct an expression like 'p => p.prop == value'
                //Creates the parameter part of an expression. So the 'p =>' part of the expression.
                ParameterExpression pe = Expression.Parameter(typeof(T), "p");
                //Get access to the property info, like the getter and setter.
                PropertyInfo pi = typeof(T).GetProperty(prop);
                // // Constructs the part of the expression where the member is referenced, so the 'p.prop' part.
                MemberExpression me = Expression.MakeMemberAccess(pe, pi);
                //Creates the constant part of the expression, the 'value' part.
                ConstantExpression ce = Expression.Constant(val);
                //creates the comparison part '==' of the expression.
                //So this requires the left and right side of 'left == right'
                //Which is the property and the constant value.
                //So 'p.prop == value'
                BinaryExpression be = Expression.Equal(me, ce);
                //Puts the 'p => ' and 'p.prop == value' parts of the expression together to form the 
                //complete lambda
                //Compile it to have an executable method according to the same signature, as 
                //specified with Func<T, bool>, so you put a class in of type T and 
                //the 'p.prop == value' is evaluated, and the result is returned.
                return Expression.Lambda<Func<T, bool>>(be, pe).Compile();
            }
        }
        public class MyType
        {
            public string p { get; set; }
        }
    }
