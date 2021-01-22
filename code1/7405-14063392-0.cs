    public class MyClass
    {
        private IDependency _myDependency;
        public MyClass(IDependency someValue = null)
        {
            _myDependency = someValue ?? GetDependency();
        }
        // If this were static, it could not be overridden
        // as static methods cannot be virtual in C#.
        protected virtual IDependency GetDependency() 
        {
            return new SomeDependency();
        }
    }
    public class MySubClass : MyClass
    {
        protected override IDependency GetDependency()
        {
            return new SomeOtherDependency();
        }
    }
    
    public interface IDependency  { }
    public class SomeDependency : IDependency { }
    public class SomeOtherDependency : IDependency { }
