    private void CountryListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateStates(ListBox1.SelectedItem.Text);
    }
    private void UpdateStates(string country)
    {
        StateListBox.DataSource = GetStates(country);
        StateListBox.DataBind();
    }
