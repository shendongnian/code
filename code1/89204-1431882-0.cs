    string[] words = { "foo", "bar", "blop" }; // your data
    Expression body = null;
    var param = Expression.Parameter(typeof(SomeType), "x");
    var id = Expression.PropertyOrField(param, "Id");
    var name = Expression.PropertyOrField(param, "Name");
    foreach (string word in words)
    {
        var wordExpr = Expression.Constant(word, typeof(string));
        var wordTest = Expression.OrElse(
            Expression.Call(id, "Contains", null, wordExpr),
            Expression.Call(name, "Contains", null, wordExpr));
        body = body == null ? wordTest : Expression.OrElse(body, wordTest);
    }
    Expression<Func<SomeType,bool>>lambda;
    if (body == null) { lambda = x => false; }
    else { lambda = Expression.Lambda<Func<SomeType, bool>>(body, param); }
