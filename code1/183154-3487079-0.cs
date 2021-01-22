    doc.Open();  // ONE
    foreach (object item in elements)
    {
        doc.Add((IElement)item);
    }
    
    // Response Output
    PdfWriter.GetInstance(doc, Response.OutputStream);
    doc.Open();  // TWO
