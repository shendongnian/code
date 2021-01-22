    protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows > 0) //this is where you check the number of rows!
        {
            //do something
        }
        else
        {
            //something else...
        }
    } 
