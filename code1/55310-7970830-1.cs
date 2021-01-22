	internal sealed class ColumnToIndexMap
	{
		private const string NameOfColumn = "ColumnName";
		private DataTable Schema { get; set; }
		private Dictionary<string, int> Map { get; set; }
		public ColumnToIndexMap(DataTable schema)
		{
			if (schema == null) throw new ArgumentNullException("schema");
			Schema = schema;
			Map = (from DataRow row in Schema.Rows
			       let columnName = (string)row[NameOfColumn]
			       select columnName)
			      .Distinct(StringComparer.InvariantCulture)
			      .Select((columnName, index) => new { Key = columnName, Value = index })
			      .ToDictionary(pair => pair.Key, pair => pair.Value);
		}
		int this[string name]
		{
			get { return Map[name]; }
		}
		string this[int index]
		{
			get { return Schema.Rows[index][NameOfColumn].ToString(); }
		}
	}
