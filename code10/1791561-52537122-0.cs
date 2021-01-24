    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[12];
            if(cell.Text == "Yes")
            {
                //Do Nothing
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "Ealert();", true);
                e.Cancel = true;
            }
        }
