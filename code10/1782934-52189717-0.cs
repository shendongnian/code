    public interface IAnimal
    {
        string Name { get; set; }
    }
    public class Animals
    {
        private readonly ConcurrentDictionary<Type, IList<IAnimal>> AnimalDictionary;
        public Animals(IList<IAnimal> animals)
        {
            this.AnimalDictionary = new ConcurrentDictionary<Type, IList<IAnimal>>();
            this.Add(animals);
        }
        public Animals(IAnimal animal)
        {
            this.AnimalDictionary = new ConcurrentDictionary<Type, IList<IAnimal>>();
            this.Add(animal);
        }
        public IList<IAnimal> Get<T>() where T : IAnimal
        {
            if (this.AnimalDictionary.ContainsKey(typeof(T)))
            {
                return this.AnimalDictionary[typeof(T)];
            }
            return (IList <IAnimal>)new List<T>();
        }
        public void Add(IList<IAnimal> animals)
        {
            foreach (IAnimal animal in animals)
            {
                this.Add(animal);
            }
        }
        public void Add(IAnimal animal)
        {
            this.AnimalDictionary.AddOrUpdate(animal.GetType(),
                new List<IAnimal>{animal}, 
                (type, list) =>
                    {
                         list.Add(animal);
                         return list;
                    });
        }
    }
