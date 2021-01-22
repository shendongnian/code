    class CustomAttribute : Attribute { }
    class Program
    {
        [Custom]
        public int Id { get; set; }
        static void Main()
        {
            Expression<Func<Program, int>> expression = p => p.Id;
            var memberExpression = (MemberExpression)expression.Body;
            bool hasCustomAttribute = memberExpression
                .Member
                .GetCustomAttributes(typeof(CustomAttribute), false).Length > 0;
        }
    }
