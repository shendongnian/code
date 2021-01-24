    //using MSWord = Microsoft.Office.Interop.Word;
    private MSWord.Document OpenDocument(MSWord.Application application, string inputPath)
    {
        var documents = application.Documents;
        foreach (MSWord.Document item in documents)
            if (item.Path.ToUpper() == inputPath.ToUpper())
                return item;
        return documents.Open(FileName: inputPath);
    }
