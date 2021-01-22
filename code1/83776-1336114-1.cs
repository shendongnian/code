    // NOT
    public static MyClass operator +(MyClass a, MyClass b) { /* ... */ }
    // YES
    public static MyClass Add(MyClass a, MyClass b) { return a.Prop + b.Prop; }
    public static MyClass operator +(MyClass a, MyClass b) { return Add(a, b); }
