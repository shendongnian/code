"a1", "b1", "c1"
"a2", "b2", "c2"
"a3", "b3", "c3"
than name the columns with column1, column2, column3, etc.. For the transpose problem I got [this solution][1].
From there I worked out this solution, where I needed a root node, which is not clear how should look like from the question>
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
            var result = myList
                .SelectMany(listRow => listRow.results.Select((item, index) => new {item, index}))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => g.Select((x, index) => new {Col = myList[index].columnName, Value = x})
                    .ToDictionary(x => x.Col, x => x.Value))
                .ToList();
            BsonDocument batch = new Dictionary<string, List<Dictionary<string, string>>> {{"root", result}}
                .ToBsonDocument();
            // {{ "root" : [{ "column1" : "a1", "column2" : "a2", "column3" : "a3" }, { "column1" : "b1", "column2" : "b2", "column3" : "b3" }, { "column1" : "c1", "column2" : "c2", "column3" : "c3" }] }}
            // Print batch
            // Add to MongoDB
        }
    }
    public class ListRow
    {
        public string columnName { get; set; }
        public List<string> results { get; set; }
    }
  [1]: https://stackoverflow.com/a/39485441/1859959
