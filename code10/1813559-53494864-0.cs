    // `Copy` used to generate a new object
    var dataTable = ds.Tables[0].Copy();
    // create a new column with your own settings (like `TimeOnly`) and add it to your new DataTable
    var newColumn = new DataColumn("TimeOnly", typeof(string)) { AllowDBNull = true };
    dataTable.Columns.Add(newColumn);
    // update your new column data based on other columns like `Column1`
    foreach (DataRow row in dataTable.Rows)
    {
        var value = DateTime.Parse(row["Column1"].ToString()).ToString("HH:mm:ss");
        row["TimeOnly"] = value;
    }
