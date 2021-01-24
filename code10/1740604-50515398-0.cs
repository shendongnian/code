    public interface IItem {
        string SomeProperty { get; }
    }
    
    public class Item : IItem {
        public string SomeProperty { get; set; }
    }
    
    public class ItemHandler {
        private Item _item = new Item();
    
        public IItem getItem() {
            _item.SomeProperty = "A Value";
            return _item;
        }
    }
    
    class Program {
        static void Main(string[] args) {
            var itemHandler = new ItemHandler();
            var item = itemHandler.getItem();
    
            // You can read the property
            Console.WriteLine(item.SomeProperty);
    
            // You can't write to the property
            //item.SomeProperty = "A New Value";
        }
    }
