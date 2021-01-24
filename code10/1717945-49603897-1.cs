    class OrganismFactory
    {
        IOrganismSubFactory[] _subFactories;
        public OrganismFactory()
        {
            _subFactories = Assembly.GetCallingAssembly().GetTypes()
                                    .Where(t => typeof(IOrganismSubFactory).IsAssignableFrom(t))
                                    .Select(t => (IOrganismSubFactory)Activator.CreateInstance(t))
                                    .ToArray();
        }
        public Organism Create(Observation observation)
        {
            return _subFactories.Select(factory => factory.Create(observation)).FirstOrDefault(instance => instance != null);
        }
    }
