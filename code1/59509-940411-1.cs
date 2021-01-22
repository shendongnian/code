    DerivedSpecificColumn.DataPropertyName = useUsers ? "UserSpecificField" : "LocationSpecificField"; // obviously need to bind to the derived field
    
    public static void BindGenericList<T>(DataGridView gridView, List<T> list)
    {
        gridView.DataSource = new BindingListView<T>(list);
    }
    
    dataGridView1.AutoGenerateColumns = false; // Be specific about which columns to show
    
