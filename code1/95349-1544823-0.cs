    class Product {
        private readonly Collection<Image> _images;
        public Product() { _images = new Collection<Image>(); }
        public Collection<Image> Images { get { return _images; } }
    }
