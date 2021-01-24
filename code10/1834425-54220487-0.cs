    var writeLine = typeof(Console).GetMethod("WriteLine", new[] {typeof(string)});
    // body of first block
    var action1 = Expression.Call(writeLine, Expression.Constant("1 or 2"));
    // body of second block
    var action2 = Expression.Call(writeLine, Expression.Constant("3, 4 or 5"));
    var value = Expression.Parameter(typeof(int), "value");
    var body = Expression.Switch(value,
        Expression.SwitchCase(
          action1,
          new[] {1, 2}.Select(i => Expression.Constant(i))),
        Expression.SwitchCase(
          action2, 
          new[] {3, 4, 5}.Select(i => Expression.Constant(i)))
    );
    var lambda = Expression.Lambda<Action<int>>(body, value);
    var method = lambda.Compile();
    method(1); // print "1 or 2"
    method(4); // print "3, 4 or 5"
