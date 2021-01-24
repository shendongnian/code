    public class A
    {
        internal void MethodVisibleToB() {}
    }
    public class B
    {
        A aInstance = new A();
    
        internal void MethodVisibleToA() 
        {
            aInstance.MethodVisibleToB(); // this can only be called by methods that are within the same assembly as B
        }
    }
