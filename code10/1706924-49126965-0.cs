    CheckBoxTableData tableData = new CheckBoxTableData();
    BindingOperations.SetBinding(tableData, CheckBoxTableData.IsCheckBoxCheckedProperty,
        new Binding("CheckMyBinding") {Source = this});
    checkBoxTable.CheckBoxData = new ObservableCollection<CheckBoxTableData>();
    checkBoxTable.CheckBoxData.Add(tableData);
