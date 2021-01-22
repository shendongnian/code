    private void ExportButton_Click(object sender, System.EventArgs e)
    {
      Response.Clear();
      Response.Buffer = true;
      Response.ContentType = "application/vnd.ms-excel";
      Response.Charset = "";
      this.EnableViewState = false;
      System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
     System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
      this.ClearControls(dataGrid);
      dataGrid.RenderControl(oHtmlTextWriter);
      Response.Write(oStringWriter.ToString());
      Response.End();
    }
