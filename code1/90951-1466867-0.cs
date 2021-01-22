    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        foreach(GridViewRow myRow in GridView1.Rows)
        {
            //Find the checkbox
            CheckBox ckbox1 = (CheckBox)myRow.FindControl("nameOfCheckBox");
            if(ckbox1.Checked)
            {
                //Find the Delete linkbutton and hide it
                LinkButton deleteButton = (LinkButton)myRow.FindControl("nameOfDeleteLinkButton");
                deleteButton.Visible = false;
            }
        }
    }
