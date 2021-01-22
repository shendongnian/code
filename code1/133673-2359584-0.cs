    public class Widgets { }
    
    public abstract class AbstractClass<T>
    {
        public int Id { get; set; }
        public int Name { get; set; }
    
        public abstract List<T> Items { get; set; }
    }
    
    public class Container : AbstractClass<Widgets>
    {
        public override List<Widgets> Items { get; set; }
    }
