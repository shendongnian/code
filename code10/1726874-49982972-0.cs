    class Program
    {
        static void Main(string[] args)
        {
            List<object> listOfObjects = new List<object>() { new Item(), new Dog(), new Cat(), new Human() };
            Dog martin = GetFirstOrDefault<Dog>(listOfObjects);
        }
        static T GetFirstOrDefault<T>(List<object> listOfObjects)
        {
            return (T)listOfObjects.Where(x => x.GetType() == typeof(T)).FirstOrDefault();
        }
    }
    class Item
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Human
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
    }
