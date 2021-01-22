    public static class ConsoleHelper
    {
        // code where idea came from ...
        //public static void IsNotNull<T>(Expression<Func<T>> expr)
        //{
        // // expression value != default of T
        // if (!expr.Compile()().Equals(default(T)))
        // return;
        // var param = (MemberExpression)expr.Body;
        // throw new ArgumentNullException(param.Member.Name);
        //}
        public static PropertyWriter WriteProperty<T>(Expression<Func<T>> expr)
        {
            var param = (MemberExpression)expr.Body;
            Console.WriteLine("Property [" + param.Member.Name + "] = " + expr.Compile()());
            return null;
        }
        public static PropertyWriter And<T>(this PropertyWriter ignored, Expression<Func<T>> expr)
        {
            ConsoleHelper.WriteProperty(expr);
            return null;
        }
        public static void Blank(this PropertyWriter ignored)
        {
            Console.WriteLine();
        }
    }
    public class PropertyWriter
    {
        /// <summary>
        /// It is not even possible to instantiate this class. It exists solely for hanging extension methods off.
        /// </summary>
        private PropertyWriter() { }
    }
