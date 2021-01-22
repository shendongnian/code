    protected void GridView1_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow myRow in GridView1.Rows)
            {
                Label Label1 = (Label)myRow.FindControl("Label1");
                if (Label1.Text == "User Data")
                {DropDownList DropDownList1 = (DropDownList)myRow.FindControl("DropDownList1");
                    DropDownList1.SelectedValue = "0";
                }
            }
        }
