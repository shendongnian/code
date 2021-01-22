    protected void Page_Load(object sender, EventArgs e)
    {
        ShowPdf(CreatePDF2());
    }
    private byte[] CreatePDF2()
    {
        Document doc = new Document(PageSize.LETTER, 50, 50, 50, 50);
        using (MemoryStream output = new MemoryStream())
        {
            PdfWriter wri = PdfWriter.GetInstance(doc, output);
            doc.Open();
            Paragraph header = new Paragraph("My Document") {Alignment = Element.ALIGN_CENTER};
            Paragraph paragraph = new Paragraph("Testing the iText pdf.");
            Phrase phrase = new Phrase("This is a phrase but testing some formatting also. \nNew line here.");
            Chunk chunk = new Chunk("This is a chunk.");
            doc.Add(header);
            doc.Add(paragraph);
            doc.Add(phrase);
            doc.Add(chunk);
            doc.Close();
            return output.ToArray();
        }
    }
    private void ShowPdf(byte[] strS)
    {
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now);
        Response.BinaryWrite(strS);
        Response.End();
        Response.Flush();
        Response.Clear();
    }
