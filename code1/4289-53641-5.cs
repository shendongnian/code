    class User
    {
      public string Name { get; set; }
      public int Age { get; set; }
    }
    public static class PredicateExtensions
    {
      public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1,Expression<Func<T, bool>> expression2)
      {
        InvocationExpression invokedExpression = Expression.Invoke(expression2, expression1.Parameters.Cast<Expression>());
        return Expression.Lambda<Func<T, bool>>(Expression.And(expression1.Body, invokedExpression), expression1.Parameters);
      }
    }
   
    class Program
    {
      static void Main(string[] args)
      {
        var user1 = new User {Name = "steve", Age = 28};
        var user2 = new User {Name = "foobar", Age = 28};
        Expression<Func<User, bool>> expression1 = t => t.Name == "steve";
        Expression<Func<User, bool>> expression2 = t => t.Age == 28;
        var result = expression1.And(expression2);
        Console.WriteLine(result.Compile().Invoke(user1));
        Console.WriteLine(result.Compile().Invoke(user2));
      }
    }
