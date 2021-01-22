    public void Foo(string x) { ... }
    public void Foo(ref string x) { ... }
    ...
    string x = "";
    Foo(x); // Which should be used if you didn't have to specify ref?
