    interface IDependency {
        int Length { get; }
        void DoSomething();
    }
    class DependencyClass : IDependency {
    public DependencyClass(int length) { Length = length; }
        ...
    }
    class MainClass {
        public MainClass(IDependency dependency) {...}
        ...
        // do something with dependency.Length
    }
