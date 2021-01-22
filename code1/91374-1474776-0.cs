    public class DocumentPresenter
    {
        private Document _document;
        
        public DocumentPresenter(Document document)
        {
            _document = document;
        }
        
        public string Title
        {
            get { return _document.Title; };
            set { _document.Title = value; };
        }
    
        public string Extension
        {
            get { return _document.Extension; };
            set { _document.Extension = value; };
        }
        
        public byte[] Data
        {
            get { return _document.Data; };
            set { _document.Data = value; };
        }
    
        public int ImageIndex
        {
            get
            {
                // some logic to return the image index...
            }
        }
    
    }
