    class Program
    {
        static void Main(string[] args)
        {
            var wife = new Human(Gender.Female);
            var baby = wife.GiveBirth();
            Console.WriteLine(baby.Gender);
    
            Console.ReadKey();
        }
    }
    
    class CanGiveBirthTo<T> where T : new()
    {
        public CanGiveBirthTo()
        {
        }
    
        public T GiveBirth()
        {
            return new T();
        }
    }
       
    class Human : CanGiveBirthTo<Human>
    {
        public Gender Gender { get; private set; }
    
        public Human(Gender gender)
        {
            Gender = gender;
        }
    
        public Human()
        {
            Gender = RandomlyAssignAGender();
        }
    
        Gender RandomlyAssignAGender()
        {
            var rand = new Random();
            return (Gender) rand.Next(2);
        }
    }
    
    enum Gender
    {
        Male = 0,
        Female = 1
    }
