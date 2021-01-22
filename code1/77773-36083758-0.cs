    public void Save(string pathToDocx)
    {
        using(StreamWriter fileStream = new StreamWriter(pathToDocx))
        {
            _document.MainDocumentPart.Document.Save(fileStream.BaseStream);
        }
    }
