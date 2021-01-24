    Event X
    {
        UpdateCombosWithSearch(cmbPItem.Text);
    }
    // ... later on ...
    private void UpdateCombosWithSearch(string searchTerm)
    {
        UpdateBrandCombo(searchTerm);
        UpdateMfgCombo(searchTerm);
        UpdateCarCombo(searchTerm);
    }
    private void UpdateBrandCombo(string searchTerm)
    {
            SqlCommand sqlCmd = new SqlCommand("select distinct car from dbo.products where Item like @item");
            sqlCmd.Parameters.Add(new SqlParameter("item", searchTerm));
            SetComboBoxUsingQuery(cmbPBrand, sqlCmd);
    }
    private void SetComboBoxUsingQuery(ComboBox cbx, SqlCommand sqlCmd)
    {
        cbx.Items.Clear();
        // code to get a DataTable from the sqlCmd
        // code to read the DataTable and add items to cbx
    }
