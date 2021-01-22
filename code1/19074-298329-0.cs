    // Domain classes
    public class Animal
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class Cat : Animal
    {
        public virtual int WhiskerLength { get; set; }
        public virtual int ClawCount { get; set; }
    }
    public class Dog : Animal
    {
        public virtual int TailWagRate { get; set; }
    }
    // Mapping file
    public class AnimalMap : ClassMap<Animal>
    {
        public AnimalMap()
        {
            Id(x => x.Id)
                .WithUnsavedValue(0)
                .GeneratedBy.Native();
            Map(x => x.Name);
            var catMap = JoinedSubClass<Cat>("CatId", sm => sm.Map(x => x.Id));
            catMap.Map(x => x.WhiskerLength)
                .CanNotBeNull();
            catMap.Map(x => x.ClawCount)
                .CanNotBeNull();
            JoinedSubClass<Dog>("DogId", sm => sm.Map(x => x.Id))
                .Map(x => x.TailWagRate)
                    .CanNotBeNull();
        }
    }
