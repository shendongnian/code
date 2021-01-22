    var pdf_filename = "pdf2read.pdf";
    using (var reader = new PdfReader(pdf_filename))
    {
        var fields = reader.AcroFields.Fields;
        foreach (var key in fields.Keys)
        {
            var value = reader.AcroFields.GetField(key);
            Console.WriteLine(key + " : " + value);
        }
    }
