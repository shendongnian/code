    [ComVisible(true)]
    public interface IMyClass  
    { 
        void Method1([In] ref UserDefinedClass[] Parameters) { ... } 
        ...
    } 
    public class MyClass : IMyClass
    {
        void IMyClass.Method1(ref UserDefinedClass[] Parameters)
        {
            this.Method1(Parameters);
        }
        public Method1(UserDefinedClass[] Parameters)
        {
            ...
        }
    }
