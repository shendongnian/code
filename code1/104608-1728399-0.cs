    class ImageCache : System.Collections.ObjectModel.KeyedCollection<string, ImageData>
    {
        protected override string GetKeyForItem(ImageData item)
        {
            return item.ImageFileName;
        }
    }
