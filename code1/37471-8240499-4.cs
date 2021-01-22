    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        myobj.myconnection();// connection created
        string mystr = "Delete table_name where water_id= '" + GridView1.DataKeys[e.RowIndex].Value + "'";// query
        sqlcmd = new SqlCommand(mystr, myobj.mycon);
        sqlcmd.ExecuteNonQuery();
        fillgrid();
    }
