    public void Pdf(string sMailBody, Response currentResponse)
    {
        StringReader sr = new StringReader(sMailBody.ToString() ));
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, 
        currentResponse.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        currentResponse.Clear();
        currentResponse.ContentType = "application/pdf";
        currentResponse.AddHeader("Content-Disposition", "attachment; "+
                                  "filename=GetPass_" + passno + ".pdf");
       currentResponse.Buffer = true;
       currentResponse.Cache.SetCacheability(HttpCacheability.NoCache);
       currentResponse.Write(pdfDoc);
       currentResponse.End();
    }
