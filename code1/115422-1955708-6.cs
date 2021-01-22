    class Program
    {
        delegate void PoorManAction (string param);
        static void Main(string[] args)
        {
    
            Dictionary<string, PoorManAction> actionMap = new Dictionary<string, PoorManAction>();
            actionMap.Add("SomeMethod1", MyClass.SomeMethod1);
            actionMap.Add("SomeMethod2", MyClass.SomeMethod2);
            actionMap.Add("SomeMethod3", MyClass.SomeMethod3);
            actionMap.Add("SomeMethod4", MyClass.SomeMethod4);
            actionMap[r["command"]]("SomeString");
    
        }
    }
