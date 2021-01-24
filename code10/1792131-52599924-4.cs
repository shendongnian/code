    string PDF_filePath = @"C:\New Folder\myPdfTest.pdf";
    Document doc = new Document();
    PdfSmartCopy copy = new PdfSmartCopy(doc, new FileStream(PDF_filePath, FileMode.Create));
    doc.Open();
    
    double qtyPages = 8; // it will be added eight pages.
    
    // In each loop iteration a page will be added "which is a Rectangle, actually"
    // with the standard size of a LETTER paper format - landscape orientation.
    for (int pag = 0; pag < qtyPages; pag++)
    {
        iTextSharp.text.Rectangle rect1 = new iTextSharp.text.Rectangle(PageSize.LETTER.Rotate());
        rect1.Border = iTextSharp.text.Rectangle.BOX;
        copy.AddPage(rect1, 0);
    }
    
    // Close the document with the changes made.
    doc.Close();
