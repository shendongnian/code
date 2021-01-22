    public override void VerifyRenderingInServerForm(Control control)
       <p> {
       <p>     /* Verifies that the control is rendered */
        <p>}
       <p> protected void GeneratePDF_Click(object sender, EventArgs e)
        {
           <p> Response.ContentType = "application/pdf";
            <p>Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
            <p>Response.Cache.SetCacheability(HttpCacheability.NoCache);
    <p>        StringWriter sw = new StringWriter();
       <p>     HtmlTextWriter hw = new HtmlTextWriter(sw);
          <p>  GridView1.AllowPaging = false;
           <p> GridView1.DataBind();
            <p>GridView1.RenderControl(hw);
            <p>GridView1.HeaderRow.Style.Add("width", "15%");
            <p>GridView1.HeaderRow.Style.Add("font-size", "10px");
            <p>GridView1.Style.Add("text-decoration", "none");
            <p>GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
           <p> GridView1.Style.Add("font-size", "8px");
            <p>StringReader sr = new StringReader(sw.ToString());
            <p>Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            <p>HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            <p>PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            <p>htmlparser.Parse(sr);
            <p>pdfDoc.Close();
            <p>Response.Write(pdfDoc);
            <p>Response.End();   
       <p>}
