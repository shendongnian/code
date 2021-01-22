    interface IMixin1
    {
        void Do1();
    }
    interface IMixin2
    {
        void Do2();
    }
    class MyClass : IMixin1, IMixin2
    {
        // implementation same as before
    }
