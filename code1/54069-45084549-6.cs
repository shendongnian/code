    public class MyClass : ICreatable1Param
    {
        public WrappedClass WrappedInstance {get; private set; }
        public MyClass() { //do something or nothing }
        public void PopulateInstance (object Param)
        {
            WrappedInstance = new WrappedClass(Param);
        }
    }
