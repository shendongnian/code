    public enum Genders { male, female, other }
    class student
    {
        public string Name;
        public int Age;
        public Genders Gender;
   
        public void Write()
        {
            Console.WriteLine("Name: {0}, Age: {1}, Gender: {2}", Name, Age, Enum.GetName(typeof(Genders ), Gender));
    
        }
    }
     class Program
    {
        static void Main(string[] args)
        {
            student student1 = new student();
            student1.Name = "Dan";
            student1.Age = 15;
            student1.Gender = Genders.male;
            student1.Write();
        }
    }
