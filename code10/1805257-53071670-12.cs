    public abstract class Animal
    {
        public Animal(JObject json)
        {
            // Initialize common fields.
        }
        public string name;
        public int age;
        public bool canBark;
    }
    public class Dog : Animal
    {
        public Dog(JObject json)
            : base(json) // Pass the json object to the Animal constructor
        {
            // Initialize dog specific fields.
        }
    }
