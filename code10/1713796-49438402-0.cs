    // Instantiate PdfFileInfo Class object.
    Aspose.Pdf.Facades.PdfFileInfo info = new Aspose.Pdf.Facades.PdfFileInfo();
    // Load your encrypted PDF document.
    info.BindPdf(dataDir + "EncryptedDocument.pdf");
    // Get DocumentPrivilege
    Facades.DocumentPrivilege documentPrivilege = info.GetDocumentPrivilege();
    // Determine AllowModifyContents
    bool AllowModifyContents = documentPrivilege.AllowModifyContents;
