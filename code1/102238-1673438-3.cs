    class News
    {
        private List<Image> images = new List<Image>();
        public ICollection<Image> Images   
        {
            get
            {
                 // You can return an ICollection interface directly from a List
                 return images;
            }
        }
     }
