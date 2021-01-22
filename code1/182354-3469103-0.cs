    // ----- this is in Assembly 1  -----------
    public ClassA
    {
        public MyInterface myDependentObject;
    }
    
    public interface MyInterface
    {
        void OtherMethod();
    }
    
    public class ClassB : MyInterface
    {
        public void OtherMethod()
        {
            // some code here...
        }
    }
    
    
    // ----- this is in Assembly 2  -----------
    public class OtherB : MyInterface
    {
        public void OtherMethod()
        {
            // some code here...
        }
    }
