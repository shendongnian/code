    SimpleClass sc = new SimpleClass();
    Expression expression = Expression.Call(
        Expression.Constant(sc),           // target-object
        "ReturnString",                    // method-name
        null,                              // generic type-argments
        Expression.Constant("hello world") // method-arguments
    );
    var lambda = Expression.Lambda<Func<string>>(expression);
    string result = sc.Return(lambda);
    Console.WriteLine(result);
