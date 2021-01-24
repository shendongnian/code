    // binary image
    DocumentData.ImageFiles.Copy(Path.GetTempPath(), -1);
    string tmpFile = Path.Combine(Path.GetTempPath(), DocumentData.UniqueDocumentID.ToString("X8")) + Path.GetExtension(ImageFileNames[0]);
    if (File.Exists(tmpFile))
    {
    	// assuming BinaryImage is of type byte[]
    	BinaryImage = File.ReadAllBytes(tmpFile);
    	File.Delete(tmpFile);
    }
    
    // binary PDF
    if (File.Exists(DocumentData.KofaxPDFFileName))
    {
    	// assuming BinaryPdf is of type byte[]
    	BinaryPdf = File.ReadAllBytes(DocumentData.KofaxPDFFileName);
    }
