    byte[] byteArray = File.ReadAllBytes("c:\\temp\\mytemplate.docx");
    using (var stream = new MemoryStream())
    {
        stream.Write(byteArray, 0, byteArray.Length);
        using (var wordDoc = WordprocessingDocument.Open(stream, true))
        {
           // Do work here
           // ...
           wordDoc.MainDocumentPart.Document.Save(); // won't update the original file 
        }
        // Save the file with the new name
        stream.Position = 0;
        File.WriteAllBytes("C:\\temp\\newFile.docx", stream.ToArray()); 
    }
