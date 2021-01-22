    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if(e.Row.RowType == DataControlRowType.DataRow)
      {
        HyperLink hyp = (HyperLink)e.Row.Findcontrol("YourHyperlinkID");
        hyp.Text = "Your New Text";
      }
    }
