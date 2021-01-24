    Please try like this
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
         //To clear existing items
         ddlUserList.Items.Clear();
        int user_type = Convert.ToInt32(ddlUserType.SelectedItem.Value);
        if (user_type == 1)
        {
    
          //your coding here....
        }
    }
