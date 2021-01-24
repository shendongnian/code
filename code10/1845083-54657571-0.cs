    private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RaceComboBox.SelectedItem.ToString() == "Warrior")
        {
            RoleComboBox.Items.Add("Tank");
            RoleComboBox.Items.Add("DPS");
        }
    }
