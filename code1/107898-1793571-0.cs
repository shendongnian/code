    private void PopulateComboBox()
    {
        DataSet Source = RetrieveDataSet();
        myComboBox.DataSource = Source;
        myComboBox.ValueMember = "MemberColumnName";
    }
    private void SaveData()
    {
        DataSet UpdatedData = GetUpdatedData();  //will put myComboBox.ValueMember into the appropriate column in UpdatedData
        DoDBSave(UpdatedData);  // Will call a serialization routine that knows how to deal with UpdatedData
    }
