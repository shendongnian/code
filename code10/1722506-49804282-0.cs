    static class Program
    {
        static void Main()
        {
            ItemCollection collection = new ItemCollection();
            Item item = new Item();
            item.ID = 1;
            item.Name = "John";
            collection.Add(item);
            List<Item> list = collection.FindAll(x => x.ID == 1 && x.Name == "John");
            ItemCollection resultCollection = new ItemCollection(list);
        }
    }
    public class ItemCollection : BaseEntityCollection<Item>
    {
        //Allow default constructor
        public ItemCollection() { }
        //Construct with a list collection
        public ItemCollection(IEnumerable<Item> collection)
            : base(collection)
        {
        }
    }
    public class Item : BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public abstract class BaseEntityCollection<T> : List<T>, IEnumerable<T> where T : BaseEntity, new()
    {
        //Still be able to create blank items
        public BaseEntityCollection() { }
        public BaseEntityCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }
    }
    public abstract class BaseEntity
    {
    }
