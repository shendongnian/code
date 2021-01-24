    public class Items
    {
        private Server { get; }
        public Items(string server) => Server = server;
        public Item Get(int id)
        {
            var item = new Item();
            //use Server inside the connectionString
            return item;
        }
        public void Save(Item item)
        {
            //use server inside the connectionstring to save the given item
        }
    }
