    public class MyList<LinkedItem> : List<LinkedItem>
    {
        public bool DoSomething()
        {
            Type t = typeof(LinkedItem);
            object o = new Object();
            var result = t.InvokeMember("ReferenceEquals",
                BindingFlags.InvokeMethod |
                BindingFlags.Public |
                BindingFlags.Static,
                null,
                null, new[] { o, o });
    
            return (result as bool?).Value;
        }
    }
    
    // call it like this:
    MyList<string> ml = new MyList<string>();
    bool value = ml.DoSomething();   // true
