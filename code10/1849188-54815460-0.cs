    public class BaseClass {
        public BaseClass(string key, object value) { ... }
    }
    public class AdapterClass : BaseClass {
        public AdapterClass (SomethingExpensive se) : BaseClass(se.key, se.value) { ... }
    }
    public class DerivedClass : AdapterClass{
        public DerivedClass (string keyValuePair) : AdapterClass(SomethingExpensive(keyValuePair)) { }
        private static KeyValuePair<string,object> SomethingExpensive(string input) { 
            // Do expensive things
            return new KeyValuePair<string,object>(derivedKey, derivedValue);
        }    
    }
