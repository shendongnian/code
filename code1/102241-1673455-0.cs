    public class News
    {
        private _images List<Images>();
        
        public IList<Image> Images
        {
            get {return _images.AsReadOnly(); }
        }
    
        public void AddImage(Image image)
        {
            _images.Add(image);
            // Do other stuff...
        }
        
        public void DeleteImage(Image image)
        {
            _images.Remove(image);
            // Do other stuff...
        }
    }
