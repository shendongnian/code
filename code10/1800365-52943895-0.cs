    FontFactory.RegisterDirectories();
    Font tnr = FontFactory.GetFont("Times New Roman", 12f, Font.NORMAL, BaseColor.BLACK);
    Font tnr_bold = FontFactory.GetFont("Times New Roman", 12f, Font.BOLD, BaseColor.BLACK);
    Font tnr_italic = FontFactory.GetFont("Times New Roman", 12f, Font.ITALIC, BaseColor.BLACK);
    
    List<IElement> elements = new List<IElement>();
    
    Paragraph p1 = new Paragraph(FormatUtility.FormatDate3(DateTime.Now), tnr);
    
    p1.SetLeading(0f, 2f); // This is the line height/line spacing
    
    elements.Add(p1);
    elements.Add(Chunk.NEWLINE);
    elements.Add(Chunk.NEWLINE);
    
    Paragraph p2 = new Paragraph();
    
    p2.SetLeading(0f, 2f); // This is the line height/line spacing
    p2.Add(new Chunk("This is to certify that ", tnr));
    p2.Add(new Chunk(name.ToUpper(), tnr_bold));
    p2.Add(new Chunk(" is currently enrolled in the ", tnr));
    .
    .
    .
    p2.Add(new Chunk(" trimester of School Year ", tnr));
    p2.Add(new Chunk(currentSchoolYearTxt, tnr_bold));
    p2.Add(new Chunk(" in the ", tnr));
    p2.Add(new Chunk(degreeProgram, tnr_bold));
    p2.Add(new Chunk(" degree program at the best school in the universe. S/He was admitted into the College on ", tnr));
    .
    .
    .
    p2.Add(new Chunk(" trimester of School Year ", tnr));
    p2.Add(new Chunk(firstSchoolYearTxt, tnr_bold));
    p2.Add(new Chunk(".", tnr));
    
    elements.Add(p2);
    elements.Add(Chunk.NEWLINE);
    
    Paragraph p3 = new Paragraph();
    
    p3.SetLeading(0f, 2f); // This is the line height/line spacing
    p3.Add(new Chunk("This certification is being issued upon the request of ", tnr));
    p3.Add(new Chunk(name, tnr_bold));
    p3.Add(new Chunk(" for ", tnr));
    p3.Add(new Chunk(specificPurpose, tnr_bold));
    p3.Add(new Chunk(".", tnr));
    
    elements.Add(p3);
    elements.Add(Chunk.NEWLINE);
    elements.Add(Chunk.NEWLINE);
    elements.Add(new Paragraph("Someone Name", tnr_bold));
    elements.Add(new Paragraph("Position", tnr));
    
    byte[] renderedBytes = CreatePDF(PageSize.LETTER, elements, 72f, 72f, 216f, 72f);
