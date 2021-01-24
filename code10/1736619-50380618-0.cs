    public interface IFruit
    {
        string Name { get; set; }
    }
    public class Apple : IFruit
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
    public class Orange : IFruit
    {
        public string Name { get; set; }
    }
