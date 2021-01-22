    public void Save(string pathToDocx)
    {
        using(FileStream fileStream = new FileStream(pathToDocx, FileMode.Create))
        {
            _document.MainDocumentPart.Document.Save(fileStream);
        }
    }
