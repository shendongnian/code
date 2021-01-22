       public interface IAmImage {}
       public class StringImage: IAmImage
       {
          private string img;
          public string Image { get { return img; } set { img = value; } }
          public StringImage(string image) { img = image;}
       }
       public class BitmapImage: IAmImage
       {
          private Bitmap img;
          public Bitmap Image { get { return img; } set { img = value; } }
          public BitmapImage(Bitmap image) { img = image;}
       }
