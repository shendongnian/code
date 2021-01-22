    public static DataTable FromEnum(this DataTable dt, Type enumType) {
	if (!enumType.IsEnum) { throw new ArgumentException("The specified type is not a System.Enum."); }
	DataTable tbl = new DataTable();
	string[] names = Enum.GetNames(enumType);
	Array values = Enum.GetValues(enumType);
	List<string> enumItemNames = new List<string>();
	List<int> enumItemValues = new List<int>();
	try {
		// build the table
		tbl.Columns.Add(new DataColumn("Value", typeof(string)));
		tbl.Columns.Add(new DataColumn("Text", typeof(string)));
		// Get the enum item names (using the enum item's description value if defined)
		foreach (string enumItemName in names) {
			enumItemNames.Add(((Enum)Enum.Parse(enumType, enumItemName)).ToDescription());
		}
		// Get the enum item values
		foreach (object itemValue in values) {
			enumItemValues.Add(Convert.ToInt32(Enum.Parse(enumType, itemValue.ToString())));
		}
		// Make sure that the data table is empty
		tbl.Clear();
		// Fill the data table
		for (int i = 0; i <= names.Length - 1; i++) {
			DataRow newRow = tbl.NewRow();
			newRow["Value"] = enumItemValues[i];
			newRow["Text"] = enumItemNames[i];
			tbl.Rows.Add(newRow);
		}
	}
	catch {
		tbl.Clear();
		tbl = dt;
	}
	// Return the data table to the caller
	return tbl;
