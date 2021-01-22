    interface IDoSomething
    {
       void DoSomething(string myParam);
    }
    
    class MyLibrary
    {
        public void DoLibraryStuff(IDoSomething iDoSomething, string extraParam)
        { iDoSomething.DoSomething("info");... }
    }
