    protected void Page_Load(object sender, EventArgs e)
    {
    	// Get sb from the session variable.
    	string sb = Session["sb"].ToString();
    
    	//Export HTML String as PDF.
    	StringReader sr = new StringReader(sb.ToString());
    	Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    	HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    
    	PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    
    	pdfDoc.Open();
    	htmlparser.Parse(sr);
    	pdfDoc.Close();
    
    	Response.ContentType = "application/pdf";
    	Response.End();
    }
