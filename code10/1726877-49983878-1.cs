    class TypeOne
    {
        public string name;
    }
    class TypeTwo
    {
        public string name;
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Test(typeof(TypeOne), new TestGenerics(), "John");
            Test(typeof(TypeTwo), new TestGenerics(), "Smith");
        }
        static void Test(Type type, TestGenerics testGenerics, String otherObjectName)
        {
            Object enumerable = testGenerics.GetType().GetMethods().FirstOrDefault(m => m.Name == "Query")
                .MakeGenericMethod(type)
                .Invoke(testGenerics, null);
            Type predicateType = typeof(Func<,>).MakeGenericType(type, typeof(bool));
            ParameterExpression predParam = Expression.Parameter(type, "i");
            Expression left = Expression.Field(predParam, type.GetField("name"));
            Expression right = Expression.Constant(otherObjectName, typeof(string));
            LambdaExpression lambda = Expression.Lambda(predicateType, Expression.Equal(left, right), predParam);
            IEnumerable<MethodInfo> methodsEnumerable = typeof(System.Linq.Enumerable)
                .GetMethods(BindingFlags.Static | BindingFlags.Public);
            MethodInfo where = methodsEnumerable.Where(m => m.GetParameters().Length == 2).FirstOrDefault(m => m.Name == "Where");
            MethodInfo genericWhere = where.MakeGenericMethod(type);
            Object response = genericWhere.Invoke(enumerable, new[] {enumerable, lambda.Compile()});
            Console.WriteLine(response);
        }
    }
    class TestGenerics
    {
        public IEnumerable<T> Query<T>() where T : new()
        {
            return Enumerable.Repeat(new T(), 10);
        }
    }
