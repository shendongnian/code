    Document document = new Document();
    MemoryStream stream = new MemoryStream();
    try
    {
        PdfWriter.GetInstance(document, stream);
        document.Open();
        document.Add(new Paragraph("Hello World"));
    }
    catch (DocumentException de)
    {
        Console.Error.WriteLine(de.Message);
    }
    catch (IOException ioe)
    {
        Console.Error.WriteLine(ioe.Message);
    }
    document.Close();
	
    stream.Flush(); //Always catches me out
	stream.Possition = 0; //Not sure if this is required
	return File(stream, "application/pdf");
