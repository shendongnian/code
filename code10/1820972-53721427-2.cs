    public sealed class ProductVm : ViewModelBase
    {
        private readonly Product model;
        private readonly Lazy<ImageSource> image;
        public ProductVm(Product model)
        {
            this.model = model;
            // we need to load image just once, hence here comes Lazy<T>
            image = new Lazy<ImageSource>(LoadImage);
            // TODO: add command initialization here;
            // usually you want DelegateCommand/RelayCommand/etc
            // AddToCartCommand = new DelegateCommand(AddToCart);
        }
        public string Name => model.Name;
        public string Description => model.Description;
        public ImageSource Image => image.Value;
        public ICommand AddToCartCommand { get; }
        private ImageSource LoadImage()
        {
            if (model.Image == null)
            {
                return null;
            }
            var image = new BitmapImage();
            using (var mem = new MemoryStream(model.Image))
            {
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
