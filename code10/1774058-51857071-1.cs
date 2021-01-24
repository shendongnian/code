    public class DependencyDispatcher : IDependency
    {
        private ImplA a;
        private ImplB b;
        public DependencyDispatcher(ImplA a, ImplB b) {
            this.a = a;
            this.b = b;
        }
        private IDependency Dependency => someCondition ? this.a : this.b;
        // Implement IDependency methods to forward the call to Dependency
        void IDependency.DoSomething() => this.Dependency.DoSomething();
    }
