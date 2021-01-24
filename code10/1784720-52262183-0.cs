    PdfPage page = pdf.AddNewPage();
    PdfCanvas pdfCanvas = new PdfCanvas(page);
    Rectangle rectangle = new Rectangle(36, 650, 100, 100);
    Canvas canvas = new Canvas(pdfCanvas, pdf, rectangle);
    PdfFont font = PdfFontFactory.createFont(FontConstants.TIMES_ROMAN);
    PdfFont bold = PdfFontFactory.createFont(FontConstants.TIMES_BOLD);
    Text title =
        new Text("The Strange Case of Dr. Jekyll and Mr. Hyde").SetFont(bold);
    Text author = new Text("Robert Louis Stevenson").SetFont(font);
    Paragraph p = new Paragraph().Add(title).Add(" by ").Add(author);
    p.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
    canvas.Add(p);
    canvas.Close();
