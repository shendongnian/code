    using System.Linq.Expressions;
    ...
        public static T DoSomethingWith(string s)
        {
          var expr = Expression.Constant(s);
          var convert = Expression.Convert(expr, typeof(T));
          return (T)convert.Method.Invoke(null, new object[] { s });
        }
