    [DebuggerTypeProxy(typeof(HashtableDebugView))]
    class MyHashtable : Hashtable
    {
        private const string TestString = 
            "This should not appear in the debug window.";
    
        internal class HashtableDebugView
        {
            private Hashtable hashtable;
            public const string TestStringProxy = 
                "This should appear in the debug window.";
    
            // The constructor for the type proxy class must have a 
            // constructor that takes the target type as a parameter.
            public HashtableDebugView(Hashtable hashtable)
            {
                this.hashtable = hashtable;
            }
        }
    }
