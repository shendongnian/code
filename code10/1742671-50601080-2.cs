    class CallingContext
    {
        private CallingContext(string name, int index)
        {
            Name = name;
            Index = index;
        }
        public string Name { get; private set; }
        public int Index { get; private set; }
    }
    public TOut GetValue<TOut>(string name, Func<CallingContext,TOut> func) { 
        var i = LookupIndex(name);
        var context = new CallingContext(name, i);        
        return func(context);
    }
