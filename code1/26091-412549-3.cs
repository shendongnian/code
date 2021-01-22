    interface IMixin1
    {
        int Property1 { get; set; }
    }
    interface IMixin2
    {
        void Do2();
    }
    class MyClass : IMixin1, IMixin2
    {
        // implementation same as before
    }
