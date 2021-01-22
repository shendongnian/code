    Try this:
    Table oTable = new Table();
    //Add data to table.
    
    Response.Clear();
    Response.Buffer = true;
    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment;filename="test.xls");
    Response.Charset = "";
    this.EnableViewState = false;
    System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
    System.Web.UI.Html32TextWriter oHtmlTextWriter = new System.Web.UI.Html32TextWriter(oStringWriter);
    0Table.RenderControl(oHtmlTextWriter);
    Response.Write(oStringWriter.ToString());
    Response.End();
