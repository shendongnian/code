	public interface IFoo
    {
        int MyProp { get; }
    }
    public interface IFooWithSetter
    {
        int MyProp { get; set; }
    }
    public class FooImplementation : IFoo, IFooWithSetter
    {
        public int MyProp
        {
            get { return 100; }
            set { }
        }
    }  
