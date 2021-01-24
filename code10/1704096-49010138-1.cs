    protected void btn_Click(object sender, EventArgs e)
            {
                foreach (GridViewRow row in gv1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox c = (CheckBox)row.FindControl("chkBox");
                        if (c.Checked)
                        {
                        }
                    }
                }
            }
