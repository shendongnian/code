    protected void grdSomething_RowDataBound ( Object sender, GridViewRowEventArgs e )
    {
        if ( e.Row.RowType == DataControlRowType.DataRow )
        {
            BusinessObject data = ( BusinessObject ) e.Row.DataItem;
            CheckBox chkLocked = ( CheckBox ) e.Row.FindControl( "chkLocked" );
            chkLocked.Checked = data.Locked;
        }
    }
