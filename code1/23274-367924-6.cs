    public abstract class Item
    {
        public int ID { get; set; }
        protected abstract void Save();
    
        public class ItemCollection : List<Item>
        {
            public void Save()
            {
                foreach (Item item in this) item.Save();
            }
        }
    }
