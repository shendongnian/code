    public class BaseAnimal : IEquatable<BaseAnimal>
    {
        public string Name { private set; get; }
        public int Value { private set; get; }
        
        public BaseAnimal(int value, String name)
        {
            this.Name = name;
            this.Value = value;
        }
        public override String ToString()
        {
            return Name;
        }
        public bool Equals(BaseAnimal other)
        {
            return other.Name == this.Name && other.Value == this.Value;
        }
    }
    public class AnimalType : BaseAnimal
    {
        public static readonly BaseAnimal Invertebrate = new BaseAnimal(1, "Invertebrate");
        public static readonly BaseAnimal Amphibians = new BaseAnimal(2, "Amphibians");
        // etc        
    }
    public class DogType : AnimalType
    {
        public static readonly BaseAnimal Golden_Retriever = new BaseAnimal(3, "Golden_Retriever");
        public static readonly BaseAnimal Great_Dane = new BaseAnimal(4, "Great_Dane");
        // etc        
    }
