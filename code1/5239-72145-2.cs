    public void ExampleFunction(Expression<Func<string, string>> f) {
        Console.WriteLine((f.Body as MemberExpression).Member.Name);
    }
    
    ExampleFunction(x => WhatIsMyName);
