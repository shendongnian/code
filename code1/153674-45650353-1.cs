    protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            List<TableOne> controlDetails = new List<TableOne>();
            controlDetails = dc.TableOne.Where(condition).ToList();
            controlDetails.Insert(0, new TableOne() { ID = 0, Name = "Select Details" });
            DropDownList ddlDetails = (e.Row.FindControl(ddlDetails) as DropDownList);
            ddlDetails.DataSource = controlDetails;
            ddlDetails.DataTextField = "Name";
            ddlDetails.DataValueField = "ID";
            ddlDetails.DataBind();
        }
    }
	protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                DataTable dtUserDetails = (DataTable)ViewState["gvUser"];
                DataRow dr = dtUserDetails.Rows[RowIndex];
                dr.Delete();
                gvUser.Rows[RowIndex].Visible = false;
            }
            else if (e.CommandName == "Edit")
            {
                DropDownList ddlDetails = (DropDownList)((GridView)sender).FooterRow.FindControl("ddlDetails");
                CheckBox CheckOne = (CheckBox)((GridView)sender).FooterRow.FindControl("CheckOne");
                CheckBox CheckTwo = (CheckBox)((GridView)sender).FooterRow.FindControl("CheckTwo");
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                DataTable dtUserDetails = (DataTable)ViewState["gvUser"];
                DataRow dr = dtUserDetails.Rows[RowIndex];
                ddlDetails.SelectedValue = dr["DetailID"].ToString();
                CheckOne.Checked = Convert.ToBoolean(dr["CheckOne"]);
                CheckTwo.Checked = Convert.ToBoolean(dr["CheckTwo"]);
                dr.Delete();
            }
            else if (e.CommandName == "Add")
            {
                DropDownList ddlDetails = (DropDownList)((GridView)sender).FooterRow.FindControl("ddlDetails");
                CheckBox CheckOne = (CheckBox)((GridView)sender).FooterRow.FindControl("CheckOne");
                CheckBox CheckTwo = (CheckBox)((GridView)sender).FooterRow.FindControl("CheckTwo");
                if (ViewState["gvUser"] != null)
                {
                    DataTable existingTable = (DataTable)ViewState["gvUser"];
                    existingTable.Rows.Add(0, Convert.ToInt32(hdnUserID.Value), 0, ddlDetails.SelectedItem.Value, ddlDetails.SelectedItem.Text, CheckOne.Checked, CheckTwo.Checked);
                    ViewState["gvUser"] = existingTable;
                    gvUser.DataSource = existingTable;
                    gvUser.DataBind();
                }
                else
                {
                    DataTable dtUsers = new DataTable();
                    dtUsers.Columns.Add("ID");
                    dtUsers.Columns.Add("UserID");
                    dtUsers.Columns.Add("DetailsID");
                    dtUsers.Columns.Add("Details");
                    dtUsers.Columns.Add("CheckOne");
                    dtUsers.Columns.Add("CheckTwo");
                    dtUsers.Rows.Add(0, Convert.ToInt32(hdnUserID.Value), 0, ddlDetails.SelectedItem.Value, ddlDetails.SelectedItem.Text, CheckOne.Checked, CheckTwo.Checked);
                    ViewState["gvUser"] = dtUsers;
                    gvUser.DataSource = dtUsers;
                    gvUser.DataBind();
                }
            }
        }
        catch (Exception)
        {
            
        }
    }
    
    //dummy function to avoid runtime grid error
	protected void gvCandidateJD_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}
	//dummy function to avoid runtime grid error
	protected void gvCandidateJD_RowEditing(object sender, GridViewEditEventArgs e)
	{
	}
	protected void btnSave_Click(object sender, EventArgs e)
	{
	  if (ViewState["gvUser"] != null)
		{
		TableOne userInfo = null;
		List<TableOne> userDetails = new List<TableOne>();
		DataTable userSpecificDetails = (DataTable)ViewState["gvUser"];
		for (int i = 0; i < userSpecificDetails.Rows.Count; i++)
		{
			userInfo = new TableOne();
			userInfo.UserID = UserID; //supply value
			foreach (DataColumn col in userSpecificDetails.Columns)
			{
				switch (col.ColumnName)
				{
					case "DetailsID":
						userInfo.DetailsID = Convert.ToInt16(userSpecificDetails.Rows[i][col.ColumnName]);
						break;
					case "CheckOne":
						userInfo.CheckOne = Convert.ToBoolean(userSpecificDetails.Rows[i][col.ColumnName]);
						break;
					case "CheckTwo":
						userInfo.CheckTwo = Convert.ToBoolean(userSpecificDetails.Rows[i][col.ColumnName]);
						break;
				}
			}
			userDetails.Add(userInfo);
		}
		if (userDetails.Count > 0)
		{
			dc.TableOne.InsertAllOnSubmit(userDetails);
			dc.SubmitChanges();
		}
     }
    }
 
