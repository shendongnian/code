    dataTable = new DataTable();//Created a new DataTable
			DataColumn dc = new DataColumn();
			dc.DataType = System.Type.GetType("System.Decimal");
			dc.ColumnName = "Price";
			DataColumn dc1 = new DataColumn();
			dc1.DataType = System.Type.GetType("System.Decimal");
			dc1.ColumnName = "qty";
			DataColumn dc2 = new DataColumn();
			dc2.DataType = System.Type.GetType("System.Decimal");
			dc2.ColumnName = "Total";
			dc2.DefaultValue = 5;
			dc2.Expression = "Price * qty";
			dataTable.Columns.Add(dc);//Add them to the DataTable
			dataTable.Columns.Add(dc1);
			dataTable.Columns.Add(dc2);
