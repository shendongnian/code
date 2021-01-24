    protected void lbDetail_Click(object sender, EventArgs e)
    {
        GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        var username = clickedRow.Cells[1].Text;
        if(string.IsNullOrEmpty(username))
        {
            return;
        }
        EmployeeID.EmpName = username;
    }
