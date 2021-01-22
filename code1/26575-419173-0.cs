    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
        // check for null first
        object displayBoxFlag = Session["DisplayBox"];
        if(displayBoxFlag!=null && (bool) displayBoxFlag)
        {
          e.Row.FindControl("chkRejectFile").Visible = true;
        }
        else
        {
          e.Row.FindControl("chkRejectFile").Visible = false;
        }
      }
    }
