    public void regionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            regionDropDown();
    
            foreach (DataRow row in mySet.Tables["Regions"].Rows)
            {
                if (regionDropDownList.SelectedValue == row["RegionID"].ToString())
                {
                    regionDescriptionLabel.Text = row["RegionDescription"].ToString();
                }
            }
        }
        catch (Exception ex) { regionDescriptionLabel.Text = "Caught!!" + ex; }
    }
