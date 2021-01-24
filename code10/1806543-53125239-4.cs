    public class Factory 
    {
        private readonly List<ABaseType> _instances;
        public Factory()
        {
            _instances = new List<ABaseType>();
        }
        public void Register<T>()  where T : ABaseType, new()
        {
            // creates a new instance of the object
            // As an alternative, save the type and create a new instance in DoTheThing()
            var instance = new T();
            _instances.Add(instance);
        }
        public void DoTheThing()
        {
            _instances.ForEach(x => x.PrintSomethingToConsole());
        }
    }
