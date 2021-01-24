    PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
    Document doc = new Document(pdfDoc, PageSize.A4, true);
    ImprovedVariableHeaderEventHandlerAlt handler = new ImprovedVariableHeaderEventHandlerAlt();
    pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, handler);
    List<int> factors;
    for (int i = 2; i < 40; i++)
    {
        doc.Add(new Paragraph(String.Format("The factors of {0}", i)).SetBold());
        handler.addHeaderDetailFor(i.ToString(), pdfDoc.GetLastPage());
        factors = getFactors(i);
        if (factors.Count == 1)
        {
            doc.Add(new Paragraph("This is a prime number!"));
        }
        foreach (int factor in factors)
        {
            doc.Add(new Paragraph("Factor: " + factor));
        }
    }
    doc.Close();
