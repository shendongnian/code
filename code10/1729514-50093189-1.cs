	private static void ShowTable(DataTable table) {
	  foreach (DataColumn col in table.Columns) {
		 Console.Write("{0,-14}", col.ColumnName);
	  }
	  Console.WriteLine();
	  foreach (DataRow row in table.Rows) {
		 foreach (DataColumn col in table.Columns) {
			if (col.DataType.Equals(typeof(DateTime)))
			   Console.Write("{0,-14:d}", row[col]);
			else if (col.DataType.Equals(typeof(Decimal)))
			   Console.Write("{0,-14:C}", row[col]);
			else
			   Console.Write("{0,-14}", row[col]);           
		 }
		 Console.WriteLine();
	  }
	  Console.WriteLine();
	}
