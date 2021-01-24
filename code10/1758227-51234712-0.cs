    DataColumn subTotalColumn = new DataColumn();
    subTotalColumn.DataType = System.Type.GetType("System.Decimal");
    subTotalColumn.ColumnName = "ItemTotal";
    subTotalColumn.Expression = "Qty * Price";
    ((Data.DataTable)dataGridView1.DataSource).Columns.Add(subTotalColumn);
