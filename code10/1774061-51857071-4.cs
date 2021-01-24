    public class DependencyDispatcher : IDependency, IApplicationContext
    {
        ...
        public AppType ApplicationType { get; set; }
        private IDependency Dependency => ApplicationType == AppType.A ? this.a : this.b;
        // Implement IDependency methods to forward the call to Dependency
        void IDependency.DoSomething() => this.Dependency.DoSomething();
    }
