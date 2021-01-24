         protected void Gridview_RowDataBound(object sender, GridViewRowEventArgs e)
         {
          if (e.Row.RowType == DataControlRowType.DataRow)
           {
            e.Row.Cells[1].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridview, "Select$" + e.Row.RowIndex);
           }
      }
