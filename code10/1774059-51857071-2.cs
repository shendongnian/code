    public class DependencyDispatcher : IDependency
    {
        ...
        private IDependency GetDependency(string appType) =>
            appType == "a" ? this.a : this.b;
        void IDependency.DoSomething(DoSomethingData data) =>
            this.GetDependency(data.AppType).DoSomething(data);
    }
