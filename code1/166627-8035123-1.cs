	class Program
	{
		static void Main(string[] args)
		{
			MyDataTable t1 = new MyDataTable();
			t1.Columns.Add(new DataColumn("Name", typeof(string)));
			t1.Columns.Add(new DataColumn("DateOfBirth", typeof(DateTime)));
			MyDataRow r1 = t1.NewRow() as MyDataRow;
			r1["Name"] = "Bob";
			r1["DateOfBirth"] = new DateTime(1970, 5, 12);
			t1.Rows.Add(r1);
		}
	}
	[Serializable]
	public class MyDataTable : DataTable
	{
		public MyDataTable()
			: base()
		{
		}
		public MyDataTable(string tableName)
			: base(tableName)
		{
		}
		public MyDataTable(string tableName, string tableNamespace)
			: base(tableName, tableNamespace)
		{
		}
		/// <summary>
		/// Needs using System.Runtime.Serialization;
		/// </summary>
		public MyDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
		protected override Type GetRowType()
		{
			return typeof(MyDataRow);
		}
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new MyDataRow(builder);
		}
	}
	[Serializable]
	public class MyDataRow : DataRow
	{
		public bool MyPropertyThatIdicatesSomething { get; private set; }
		public MyDataRow()
			: base(null)
		{
		}
		public MyDataRow(DataRowBuilder builder)
			: base(builder)
		{
		}
	}
