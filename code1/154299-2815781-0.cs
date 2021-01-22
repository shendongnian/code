	using iTextSharp.text;
	using iTextSharp.text.pdf;
	Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
	
	byte[] pdfBytes;
	using(var mem = new MemoryStream())
	{
		using(PdfWriter wri = PdfWriter.GetInstance(doc, mem)) 
		{
			doc.Open();//Open Document to write
			Paragraph paragraph = new Paragraph("This is my first line using Paragraph.");
			Phrase pharse = new Phrase("This is my second line using Pharse.");
			Chunk chunk = new Chunk(" This is my third line using Chunk.");
			
			doc.Add(paragraph);
			
			doc.Add(pharse);
			
			doc.Add(chunk);	
		}
		pdfBytes = mem.ToArray();
	}
