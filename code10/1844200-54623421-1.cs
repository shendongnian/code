    void Main()
    {
        BothSyntax test= new BothSyntax();
        test.dyn.greeting = "Hi";
        
        Console.WriteLine(test["greeting"]);
        
        test["name"] = "Joe";
        Console.WriteLine(test.dyn.name);
    }
    class BothSyntax
    {
        public dynamic dyn => eo;
        private ExpandoObject eo = new ExpandoObject();
        public object this[string key] 
        { 
            get
	    {
                return ((IDictionary<string, object>)eo)[key];
            }
            set
            {
                ((IDictionary<string, object>)eo)[key] = value;
            }
        }
    }
