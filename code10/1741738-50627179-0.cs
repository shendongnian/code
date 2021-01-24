    //Initialize PDFA document with output intent
    PdfADocument pdf = new PdfADocument(new PdfWriter(dest), PdfAConformanceLevel.PDF_A_1B, new PdfOutputIntent
                ("Custom", "", "http://www.color.org", "sRGB IEC61966-2.1", new FileStream("sRGB_CS_profile.icm", FileMode.Open, FileAccess.Read
                )));
    
    Document document = new Document(pdf);
    //Fonts need to be embedded
    PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.WINANSI, true);
    Paragraph p = new Paragraph();
    p.SetFont(font);
    p.Add(new Text("The quick brown "));
    
    iText.Layout.Element.Image foxImage = new Image(ImageDataFactory.Create(FOX));    
    p.Add(foxImage);
    p.Add(" jumps over the lazy ");
    iText.Layout.Element.Image dogImage = new iText.Layout.Element.Image(ImageDataFactory.Create(DOG));
    p.Add(dogImage);
    document.Add(p);
    document.Close();
