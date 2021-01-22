    public class News
    {
        private IList<Image> _images;
        public void News()
        {
            _images = new List<Image>();
        }
    
        public void AddImage(Image image) { ... }
        public void RemoveImage(Image image) { ... }
        public IEnumberable<Image> Images
        {
            get { return _images; }
        }
    }
