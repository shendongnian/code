    public static void ComboFilter(ComboBox cb, DataTable dtSource, TextBox filterTextBox)
    {
    	cb.DropDownStyle = ComboBoxStyle.DropDownList;
    	string displayMember = cb.DisplayMember;
    	DataView filterView = new DataView(dtSource);
    	DataRowView newRow = filterView.AddNew();
    	newRow[displayMember] = "";
    	try { newRow.EndEdit(); }	// fails, if a column in dtSource does not allow null
    	catch (Exception) { }		// works, but the empty line will appear at the end
    	filterView.RowFilter = displayMember + " LIKE '%" + filterTextBox.Text + "%'";
    	filterView.Sort = displayMember;
    	cb.DataSource = filterView;
    }
