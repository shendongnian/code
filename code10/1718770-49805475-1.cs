    public class ConcreteMainClass : CommonMainClass //you can derive from common, delegate to inner instance or implement interface from scratch - you decide depending on situation
    {
        private readonly IDerivedB _instance;
        public ConcreteMainClass(IDerivedB instance) : base(instance)
        {
            _instance = instance;
        }
        //you can override some logic here depending on IExistable<string> from IDerivedB
    }
    public class CommonMainClass : IMainClass
    {
        private readonly IExistable<int> _instance;
        public CommonMainClass(IExistable<int> instance)
        {
            _instance = instance;
        }
        //this is where you don't depend on IExistable<string>
    }
