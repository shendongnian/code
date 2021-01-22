    Dictionary<Type, int> typeDict = new Dictionary<Type, int>
    {
        {typeof(int),0},
        {typeof(string),1},
        {typeof(MyClass),2}
    };
    
    void Foo(object o)
    {
        switch (typeDict[o.GetType()])
        {
            case 0:
                Print("I'm a number.");
                break;
            case 1:
                Print("I'm a text.");
                break;
            case 2:
                Print("I'm classy.");
                break;
            default:
                break;
        }
    }
