    public interface ComVisibleFoo
    {
        int SomeProperty { get; set; }
        
        //Dictionary<string, object> Items; // can't be COM-visible
        
        void AddItem(string key, object value);
        void RemoveItem(string key);
        object Item(string key);
    }
