    public <ActionResult> SomeFunction() {
        var invoices = GetInvoices();
        WebClient client = new WebClient();
        byte[] zipBytes = null;
    
        using (var compressedFileStream = new MemoryStream()) {
            using (ZipArchive zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, leaveOpen: true)) {
                foreach (var invoice in invoices) {
                    // This has correct values.
                    byte[] fileBytes = client.DownloadData(invoice.XmlUri);
    
                    // Create the instance of the file.
                    var zipEntry = zipArchive.CreateEntry(invoice.XmlFileName);
    
                    // Get the stream of the file.
                    using (var entryStream = new MemoryStream(fileBytes))
    
                    // Get the Stream of the zipEntry
                    using (var zipEntryStream = zipEntry.Open()) {
                        // Adding the file to the zip file.
                        entryStream.CopyTo(zipEntryStream);
                    }
                }            
            }
            zipBytes = compressedFileStream.ToArray();
        }
        return File(zipBytes , System.Net.Mime.MediaTypeNames.Application.Octet, "test.zip");
    }
