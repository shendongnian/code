    public class Person
    {
        private IList<Pet> pets;
        protected Person()
        {}
        public Person(string name)
        {
            Name = name;
            pets = new List<Pet>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IEnumerable<Pet> Pets
        {
            get { return pets; }
        }
        public virtual void AddPet(Pet pet)
        {
            pets.Add(pet);           
        }
    }
    public class Pet 
    {
        protected Pet()
        {}
        public Pet(string name)
        {
            Name = name;
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            HasMany(x => x.Pets).Cascade.AllDeleteOrphan().Access.AsLowerCaseField();
        }
    }
    public class PetMap : ClassMap<Pet>
    {
        public PetMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
        }
    }
