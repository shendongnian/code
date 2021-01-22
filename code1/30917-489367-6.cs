    public class Item { 
        public string Name { get; set; }
    }
    public class ItemFilter {
        public string Name { get; set; }
        public ItemFilter(string name) {
            Name = name;
        }
        public bool FilterByName(Item i) {
            return i.Name.Equals(Name);
        }
    }
    public class ItemsTest {
        private static List<Item> HowMayItems(List<Item> l,params ItemFilter[] values)
        {
            List<Item> results= new List<Item>();
            foreach(ItemFilter f in values){
                Predicate<Item> p = new Predicate<Item>(f.FilterByName);
                List<Item> subList = l.FindAll(p);
                results.Concat(subList);
            }
            return results;
        }
    }
