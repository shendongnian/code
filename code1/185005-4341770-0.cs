    //  Load data from database (not shown)
    // _dataSet.Tables["lstCountries"] datasource for cboCountry
    // _dataSet.Tables["lstStates"] datasource for cboState
    //  
    // cboCountry - comboDropDown - List on countries 
    // cboState  = comboDropDown  - List of states
    // Use boolean bloading to prevent setting datasource for cboState when cboCountry is intially loaded.
        void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (sender as ComboBox);
            if (cbo.SelectedIndex > -1 && !bloading)
            {
                Int32 countryID = Convert.ToInt32(((System.Data.DataRowView)(cbo.SelectedItem)).Row.ItemArray[0].ToString());
                cboState.Text = "";
                DataView view = _dataSet.Tables["lstStates"].DefaultView;
                view.RowFilter = string.Format("CountryID={0}", countryID);
                DataTable table = view.ToTable();
                cboState.DataSource = table;
                cboState.SelectedIndex = -1;
        }
