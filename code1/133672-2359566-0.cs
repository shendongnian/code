    public class AbstractClass<T>
    {
        public int Id { get; set; }
        public int Name { get; set; }
    
        public abstract List<T> Items { get; set; }
    }
    
    public class Container : AbstractClass<Widget>
    {
        public List<Widgets> Items { get; set; }
    }
