    namespace AbstractGeneric
    {
    public abstract class AbstractClass<T>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public abstract List<T> Items { get; set; }
    }
    public class Widgets
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Container : AbstractClass<Widgets>
    {
        public override List<Widgets> Items { get; set; }
        public Container()
        {
            Items = new List<Widgets>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Container c = new Container();
            c.Items.Add(new Widgets() { ID = 1, Name = "Sample Widget 1" });
            c.Items.Add(new Widgets() { ID = 2, Name = "Sample Widget 2" });
            foreach (Widgets item in c.Items)
            {
                Console.WriteLine(item.ID + " : " + item.Name);
            }
            Console.ReadLine();
        }
    }
    }
