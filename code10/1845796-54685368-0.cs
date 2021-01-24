    class Variable<T>
    {
       public Variable(T value) { Value = value; }
       public T Value { get; set; }
    }
    
    var s = new Variable<string>("Test");
    var list = new List<Variable<string>>();
    
    list.Add(s);
