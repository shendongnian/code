    PdfPTable table = new PdfPTable(1);
    string text = "blab balba b balbala ";
    string finalText = "TestTitle1\r\n\r\n";
    
    for (int i = 0; i < 200; ++i)
    {
         finalText += text;
    }
    table.AddCell(finalText);
    table.TotalWidth = 300;
    table.WriteSelectedRows(0, -1, 20, 325, pdfstamper.GetUnderContent(1));
