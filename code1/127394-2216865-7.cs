    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            var definitions = Assembly.GetExecutingAssembly().GetTypes()
                .GetBindingDefinitionOf(typeof(IRepository<>));
            
            foreach (var definition in definitions)
            {
                Bind(definition.Service).To(definition.Implementation);
            }
        }
    }
