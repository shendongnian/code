    protected void UnknownBloodType_CheckedChanged(object sender, EventArgs e)
    {
        //set the dll to default
        BloodType.SelectedValue = "";
        //cast the sender back to a checkbox and disable the dll based on it's checked status
        BloodType.Enabled = !((CheckBox)sender).Checked;
    }
