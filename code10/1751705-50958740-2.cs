    class MyUnion
    {
       object obj;
       MyUnion(SomeType o) { obj = o; }
       //... constructors for all accepted Types
       public object Value { get { return obj; } }
    }
