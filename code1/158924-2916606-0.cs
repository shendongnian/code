    private void MakeDataView() 
    {
        DataView view = new DataView();
    
        view.Table = DataSet1.Tables["Countries"];
        view.RowFilter = "CountryName = 'France'";
        view.RowStateFilter = DataViewRowState.ModifiedCurrent;
    
        // Simple-bind to a TextBox control
        Text1.DataBindings.Add("Text", view, "CountryID");
    }
