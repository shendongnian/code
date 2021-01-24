	public class TestTableRow
	{
		public TestTableRow(int id, int start, int end)
		{
			Id = id;
			Start = start;
			End = end;
		}
		public int Id { get; set; }
		public int Start { get; set; }
		public int End { get; set; }
	}
	public class TestTable
	{
		private IList<TestTableRow> _rows = new List<TestTableRow>();
		public void AddRow(TestTableRow row)
		{
			_rows.Add(row);
		}
		// I'm assuming there can only be zero or 1 matches, otherwise this would need to be rewritten to return a list.
		public int? FindExactStart(params int[] requiredEndIds)
		{
			var groupings = _rows.GroupBy(x => x.Start);
			foreach (var grouping in groupings)
			{
				var actualEndIds = grouping.Select(x => x.End).ToList();
				// We need to check that all the actual ends are in the list, and that there are no others.
				if (actualEndIds.All(x => requiredEndIds.Contains(x)) && requiredEndIds.Except(actualEndIds).Any() == false)
				{
					return grouping.Key;
				}
			}
			return null;
		}
	}
	public class Program
	{
		public static void Main(string[] args)
		{
			var testTable = new TestTable();
			testTable.AddRow(new TestTableRow(1, 1, 1));
			testTable.AddRow(new TestTableRow(2, 1, 2));
			testTable.AddRow(new TestTableRow(3, 2, 5));
			testTable.AddRow(new TestTableRow(4, 2, 1));
			testTable.AddRow(new TestTableRow(5, 3, 2));
			var firstAnswer = testTable.FindExactStart(new[] { 1, 2 });
			Console.WriteLine("First answer: " + firstAnswer);
			var secondAnswer = testTable.FindExactStart(new[] { 1, 2, 5 });
			Console.WriteLine("Second answer: " + secondAnswer);
		}
	}
