    var keyDictionary = new Dictionary<string, IEnumerable<string>>();
    keyDictionary.Add("Table1", new List<string> {"Group", "Position"});
    var dt = new DataTable("Table1");
    dt.Columns.AddRange(new [] { new DataColumn("Id", typeof(int)), new DataColumn("Group", typeof(string)), new DataColumn("Position", typeof(string)), new DataColumn("Name", typeof(string))});
    var rowItemArrays = new [] { new object[] { 1, "Alpha", "Left", "Bob" }, new object[] { 2, "Alpha", "Right", "Mary"}, new object[] { 3, "Beta", "Right", "Bill"}, new object[] { 4, "Alpha", "Right", "Larry"}};
    rowItemArrays.ToList().ForEach(i => dt.Rows.Add(i));
    Func<DataRow, string> GetKeys = (dataRow) => string.Join("", keyDictionary[dataRow.Table.TableName].Select(key => dataRow[key].ToString()).ToArray());
    var a = dt.AsEnumerable().GroupBy(GetKeys);
