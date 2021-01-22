    private static void Foo()
    {
        DisplayClass locals = new DisplayClass();
        locals.someStruct = new SomeStruct { Num = 5 };
        action = new Action(locals.b__1);
    }
    private sealed class DisplayClass
    {
        // Fields
        public SomeStruct someStruct;
        // Methods
        public void b__1()
        {
            Console.WriteLine(this.someStruct.Num);
        }
    }
