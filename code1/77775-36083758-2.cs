        public void Load(string pathToDocx)
        {
            _tempFilePath = CloneFileInTemp(pathToDocx);
            _document = WordprocessingDocument.Open(_tempFilePath, true);
            _documentElement = _document.MainDocumentPart.Document;
        }    
    
        public void Save(string pathToDocx)
        {
            using(FileStream fileStream = new FileStream(pathToDocx, FileMode.Create))
            {
                _document.MainDocumentPart.Document.Save(fileStream);
            }
        }
