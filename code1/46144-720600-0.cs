    public class Table {
        public string Name {get; internal set; }
    }
    public class Database {
        public IList<Table> Tables { get; private set;}
        
        public Database(){
            this.Tables = new List<Table>();
        }
    }
