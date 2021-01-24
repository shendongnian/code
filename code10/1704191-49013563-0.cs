    try{
        using (var document = new Doc())
        {
           document.Read(pdfPath);
        }
    }
    catch(Exception){
        Console.WriteLine("Exception thrown when attempting to read pdf");
    }
