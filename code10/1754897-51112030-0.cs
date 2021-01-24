    // Open document
    Document pdfDocument = new Document(dataDir + "GetFileInfo.pdf");
    // Get document information
    DocumentInfo docInfo = pdfDocument.Info;
    // Show document information
    Console.WriteLine("Author: {0}", docInfo.Author);
    Console.WriteLine("Creation Date: {0}", docInfo.CreationDate);
    Console.WriteLine("Keywords: {0}", docInfo.Keywords);
    Console.WriteLine("Modify Date: {0}", docInfo.ModDate);
    Console.WriteLine("Subject: {0}", docInfo.Subject);
    Console.WriteLine("Title: {0}", docInfo.Title);
    Facades.PdfFileInfo fileInfo = new Facades.PdfFileInfo(pdfDocument);
    fileInfo.GetPdfVersion();
