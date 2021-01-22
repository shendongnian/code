    public interface IMyInterface
    {
        int MyProperty { get; set; }
    }
    
    public abstract class MyInterfaceBase : IMyInterface
    {
        int myProperty;
    
        public int MyProperty
        {
            get { return myProperty; }
            set { myProperty = value; }
        }
    }
