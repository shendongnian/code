    interface IDoSomething
    {
       void DoSomething();
    }
    
    class MyLibrary
    {
        public void DoLibraryStuff(IDoSomething iDoSomething)
        { iDoSomething.DoSomething();... }
    }
