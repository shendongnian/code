    public class AnimalRegistry
    {
        Dictionary<Type, object> registry = new Dictionary<Type, object>();
    
        public void Register<TService, TAnimal>()
            where TService : Factory<TAnimal>, ISerialize, new()
            where TAnimal : Animal
        {
            TService service = new TService();
    
            registry[service.GetType()] = service;
            registry[service.TypeCreated] = service;
        }
    
        public Factory<TAnimal> GetInstance<TAnimal>()
            where TAnimal : Animal
        {
            return (Factory<TAnimal>)registry[typeof(TAnimal)];
        }
    
        public string Serialize(Animal animal)
        {
            return ((ISerialize)registry[animal.GetType()]).Serialize(animal);
        }
    }
