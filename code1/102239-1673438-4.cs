    class News
    {
        private List<Image> images = new List<Image>();
        public ReadOnlyCollection<Image> Images   
        {
            get
            {
                 // This wraps the list in a ReadOnlyCollection object so it doesn't actually copy the contents of the list just a reference to it
                 return images.AsReadOnly();
            }
        }
     }
