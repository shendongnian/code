    public class MyClass
    {
        private string _MyProperty;
    
        public MyProperty { get { return _MyProperty; } }
    
        public MyClass ()
        {
            _MyProperty = SomeVeryComplexPropertyInitializationLogic ();
        }
    }
