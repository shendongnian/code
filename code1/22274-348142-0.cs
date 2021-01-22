    public abstract class BaseClass
    {
        public IUnityContainer Container { get; protected set; }
        
        public BaseClass() : BaseClass(null) {}
         
        public BaseClass( IUnityContainer container )
        {
            this.container = container ?? this.CreateContainer();
        }
        public abstract IUnityContainer CreateContainer();
    }
    public class DerivedClass : BaseClass
    {
        public IUnityContainer ChildContainer { get; private set; }
        public DerivedClass() : DerivedClass(null,null) {}
        public DerivedClass( IUnityContainer parent, IUnityContainer child )
            : BaseClass( parent )
        {
            this.ChildContainer = child ?? this.CreateChildContainer();
        }
        public IUnityContainer CreateContainer()
        {
             return new UnityContainer();
        }
        public IUnityContainer CreateChildContainer()
        {
             return this.Container.CreateChildContainer();
        }
    }
     
