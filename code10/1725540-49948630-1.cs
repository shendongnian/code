    protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridEditableItem editedItem)
        {
            var strUserID = Convert.ToString(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["UserID"]);
            var intUserId = Convert.ToUInt16(strUserID);
    
            using (ExpungeEntities db = new ExpungeEntities())
            {
                var Results = db.USERS_T_DATA.SingleOrDefault(i => i.UserID == intUserId);
                if (Results == null)
                {
                    RadGrid1.Controls.Add(new LiteralControl("Unable to locate that user for updating"));
                    e.Canceled = true;
                    return;
                }
                if (editedItem.FindControl("ddlRoles") is DropDownList ddlRoles)
                    Results.Role = ddlRoles.SelectedValue;
                if (editedItem.FindControl("FirstName") is TextBox txtFirstName)
                    Results.FirstName = txtFirstName.Text;    
            }
        }
    }
