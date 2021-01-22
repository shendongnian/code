    public enum ItemTypes{
        Balloon,
        Cupcake,
        WaterMelon
        //Add the rest of the 26 items here...
    }
    public class ItemFilter {
        private ItemTypes Type { get; set; }
        public ItemFilter(ItemTypes type) {
            Type = type;
        }
        public bool FilterByType(ItemTypes type) {
            return this.Type == type;
        }
    }
    
    public class PicnicTable {
        private List<ItemTypes> Items;
        public PicnicTable() {
            Items = new List<ItemTypes>();
        }
        public void AddItem(ItemTypes item) {
            Items.Add(item);
        }
        public int HowMayItems(ItemTypes item)
        {
            ItemFilter filter = new ItemFilter(item);
            Predicate<ItemTypes> p = new Predicate<ItemTypes>(filter.FilterByType);
            List<ItemTypes> result = Items.FindAll(p);
            return result.Count;
        }
    }
    public class ItemsTest {
        public static void main(string[] args) {
            PicnicTable table = new PicnicTable();
            table.AddItem(ItemTypes.Balloon);
            table.AddItem(ItemTypes.Cupcake);
            table.AddItem(ItemTypes.Balloon);
            table.AddItem(ItemTypes.WaterMelon);
            Console.Out.WriteLine("How Many Cupcakes?: {0}", table.HowMayItems(ItemTypes.Cupcake));
        }
    }
