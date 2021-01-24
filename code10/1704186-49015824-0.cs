    public class Data {
        string Server = "";
        public Data(string Server) {
            this.Server = Server;
        }
        public Item Item_Get(int Id) {
            var result = new Item();
            // here im am using sql connection to set result, but i need Server value in connnection string
            return result;
        }
    }
    public class Item {
        public int Id { get; set; }
        public string Name { get; set; }
    }
