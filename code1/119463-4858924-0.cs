    private void OrderByComboBoxColumn()
    {
    // Add the temp Column if it doesnt exist
    if (!dataset.TABLE.Columns.Contains("TempColumn"))
        dataset.TABLE.Columns.Add("TempColumn", typeof(string));
    foreach (DataSetRow row in dataset.TABLE)
        row["TempColumn"] = GetBoundValue(row.COMBOBOX_ID);
    
    dataview.Sort = "TempColumn ASC";
    
    }
    private string GetBoundValue(int id)
    {
	// get the string however your id matches the bound value
	return string;
    }
