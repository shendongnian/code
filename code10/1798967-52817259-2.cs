    Response.ClearContent();
    Response.ContentType = "application/ms-word";
    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.doc", "WordFileName"));
    Response.Charset = "";
    System.IO.StringWriter stringwriter = new System.IO.StringWriter();
    HtmlTextWriter htmlwriter = new HtmlTextWriter(stringwriter);
    gv.RenderControl(htmlwriter);
    Response.Write(stringwriter.ToString());
    Response.End();
