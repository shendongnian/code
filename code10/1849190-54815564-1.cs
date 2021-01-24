    public class DerivedClass : BaseClass {
        public DerivedClass (string keyValuePair)
            : this(SomethingExpensive(keyValuePair)) { }
        private DerivedClass (Tuple<string,object> arguments)
            : BaseClass(arguments.Item1, arguments.Item2)
    
        private static Tuple<string,object> SomethingExpensive(string input) { 
             // Do expensive things
             return Tuple.Create(derivedKey, derivedValue);
        }    
    }
