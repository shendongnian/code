    public class SomeViewPopulator : IViewPopulator
    {
        private readonly IDependency dep;
        public SomeViewPopulator(IDependency dep)
        {
            if (dep == null)
            {
                throw new ArgumentNullException("dep");
            }
            this.dep = dep;
        }
        public void Populate(IView view)
        {
            var vm = // Perhaps use this.dep to create an instance of IViewModel...
            view.ViewModel = vm;
        }
    }
