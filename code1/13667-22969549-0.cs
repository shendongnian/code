    /// <summary>
    /// AlphabetizeDropDownList alphabetizes a given dropdown list by it's displayed text.
    /// </summary>
    /// <param name="dropDownList">The drop down list you wish to modify.</param>
    /// <remarks></remarks>
    private void AlphabetizeDropDownList(ref DropDownList dropDownList)
    {
        //Create a datatable to sort the drop down list items
        DataTable machineDescriptionsTable = new DataTable();
        machineDescriptionsTable.Columns.Add("DescriptionCode", typeof(string));
        machineDescriptionsTable.Columns.Add("UnitIDString", typeof(string));
        machineDescriptionsTable.AcceptChanges();
        //Put each of the list items into the datatable
        foreach (ListItem currentDropDownListItem in dropDownList.Items) {
                string currentDropDownUnitIDString = currentDropDownListItem.Value;
                string currentDropDownDescriptionCode = currentDropDownListItem.Text;
                DataRow currentDropDownDataRow = machineDescriptionsTable.NewRow();
                currentDropDownDataRow["DescriptionCode"] = currentDropDownDescriptionCode.Trim();
                currentDropDownDataRow["UnitIDString"] = currentDropDownUnitIDString.Trim();
                machineDescriptionsTable.Rows.Add(currentDropDownDataRow);
                machineDescriptionsTable.AcceptChanges();
        }
        //Sort the data table by description
        DataView sortedView = new DataView(machineDescriptionsTable);
        sortedView.Sort = "DescriptionCode";
        machineDescriptionsTable = sortedView.ToTable();
        //Clear the items in the original dropdown list
        dropDownList.Items.Clear();
        //Create a dummy list item at the top
        ListItem dummyListItem = new ListItem(" ", "-1");
        dropDownList.Items.Add(dummyListItem);
        //Begin transferring over the items alphabetically from the copy to the intended drop
         downlist
        foreach (DataRow currentDataRow in machineDescriptionsTable.Rows) {
                string currentDropDownValue = currentDataRow["UnitIDString"].ToString().Trim();
                string currentDropDownText = currentDataRow["DescriptionCode"].ToString().Trim();
                ListItem currentDropDownListItem = new ListItem(currentDropDownText, currentDropDownValue);
		//Don't deal with dummy values in the list we are transferring over
		if (!string.IsNullOrEmpty(currentDropDownText.Trim())) {
			dropDownList.Items.Add(currentDropDownListItem);
		}
	}
