    protected void myGrdiView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            myObjectType ot = (myObjectType)e.Row.DataItem;
            ot.myNumber = ot.myNumber * 100; // multiply by 100
        }
    }
