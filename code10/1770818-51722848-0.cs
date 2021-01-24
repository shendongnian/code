    class Program
    {
        class MyType
        {
            public int Column { get; set; }
        };
    
        public static string AsString(object obj)
        {
            return obj?.ToString();
        }
    
        static void Main(string[] args)
        {
            var param = Expression.Parameter(typeof(MyType));
            //your member
            MemberExpression member = Expression.Property(param, "Column");
            var asString = typeof(Program).GetMethod("AsString");
            var stringMember = Expression.Call(asString, Expression.Convert(member, typeof(object)));
            //your value
            ConstantExpression constant = Expression.Constant("23");
            //your switch
            var expression = Expression.Equal(stringMember, constant);
    
            var lambda = Expression.Lambda(expression, param);
            var list = new List<MyType>
            {
                new MyType{Column = 23},
                new MyType{Column= 24}
            };
            var res = list.Where((Func<MyType,bool>)lambda.Compile()).ToList();
        }
    }
