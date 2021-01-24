    using System;
    
    public interface In1
    {
        int MyProperty { get; }
    
        bool Check { get; }
    }
    
    class TestProp : In1
    {
        // use a ternary
        public int MyProperty => Check ? 1 : 0;
    
        // or a Lazy, if you want to emulate Scala
        public int MyOtherProperty => 
            new Lazy<int>(() => { if (Check) return 1; else return 0; }).Value;
    
        public bool Check => true;
    }
