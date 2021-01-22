    abstract class TestClass<T>
    {
        public List<T> Items { get; set; }
    
        // other generic (i.e. non type-specific) code
    }
    
    class IntTestClass : TestClass<int>
    {
        public string GetName()
        {
            // do work knowing that the type is an int
        }
    
        // other code specific to the int case
    }
    
    class StringTestClass : TestClass<string>
    {
        public string GetName()
        {
            // do work knowing that the type is a string
        }
    
        // other code specific to the string case
    }
