    public string ExampleFunction(Expression<Func<string, string>> f) {
        Console.WriteLine(f.Parameters[0]);
    }
    
    ExampleFunction(WhatIsMyName => WhatIsMyName);
