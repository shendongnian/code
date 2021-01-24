    class Program
    {
        static void Main(string[] args)
        {
            List<ListRow> myList = new List<ListRow>
            {
                new ListRow {columnName = "column1", results = new List<string> {"a1", "b1", "c1"}},
                new ListRow {columnName = "column2", results = new List<string> {"a2", "b2", "c2"}},
                new ListRow {columnName = "column3", results = new List<string> {"a3", "b3", "c3"}}
            };
            BsonDocument batch = myList.ToDictionary(x => x.columnName, x => x.results).ToBsonDocument();
            // Print batch
            // Add to MongoDB
        }
    }
    public class ListRow
    {
        public string columnName { get; set; }
        public List<string> results { get; set; }
    }
