    protected void btnSave_Click(object sender, EventArgs e) 		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (row.RowType==DataControlRowType.DataRow)
				{
					CheckBox chkbox = (CheckBox)row.Cells[0].FindControl("chkbox");
					HiddenField hdID = (HiddenField)row.Cells[0].FindControl("id");
					Label lbl = (Label)row.Cells[0].FindControl("lblUpdate");
					if (chkbox!=null)
					{
						if(chkbox.Checked)
						{
							string Id = hdID.Value;
							//now update name...  here by the help of this RowId===> Id
						}
					}
				}
				
			}
