    public interface IProduct
    {
         ICollection<Image> Images { get; }
    }
    public class Product : IProduct
    {
       private class ImageCollection : Collection<Image>
       {
          // override InsertItem, RemoveItem, etc.
       }
       private readonly ImageCollection _images;
       public ICollection<Image> Images
       {
          get { return _images; }
       }
    }
