    public interface IAnimal
    {
        string Name { get; set; }
    }
    public class Dog : IAnimal
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class Cat : IAnimal
    {
        public string Name { get; set; }
        public string Size { get; set; }
    }
