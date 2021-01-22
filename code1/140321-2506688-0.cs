DataTable myDataTable = new DataTable();
			myDataTable.Columns.Add("OrderID", typeof(int));
			myDataTable.Columns.Add("Date", typeof(DateTime));
			myDataTable.Columns.Add("UnitsPurchased", typeof(int));
			var datarow1 = myDataTable.NewRow();
			datarow1.SetField("OrderID", 16548);
			datarow1.SetField("Date", DateTime.Parse("10/10/09"));
			datarow1.SetField("UnitsPurchased", 250);
			var datarow2 = myDataTable.NewRow();
			datarow2.SetField("OrderID", 17984);
			datarow2.SetField("Date", DateTime.Parse("11/03/09"));
			datarow2.SetField("UnitsPurchased", 512);
			var datarow3 = myDataTable.NewRow();
			datarow3.SetField("OrderID", 20349);
			datarow3.SetField("Date", DateTime.Parse("01/11/10"));
			datarow3.SetField("UnitsPurchased", 213);
			var datarow4 = myDataTable.NewRow();
			datarow4.SetField("OrderID", 34872);
			datarow4.SetField("Date", DateTime.Parse("10/01/10"));
			datarow4.SetField("UnitsPurchased", 175);
			myDataTable.Rows.Add(datarow1);
			myDataTable.Rows.Add(datarow2);
			myDataTable.Rows.Add(datarow3);
			myDataTable.Rows.Add(datarow4);
			var filteredTable = myDataTable.AsEnumerable().OfType<DataRow>().Where(row => row.Field<int>("UnitsPurchased") > 200).Select(r => r);
			resultDataTable.DataSource = filteredTable.CopyToDataTable();
  
 </pre>
