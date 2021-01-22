    public class Basket<T> {
      T[] basketItems;
    }
    
    public class PicnicBlanket<T> {
      Basket<T> picnicBasket;   // Open type here. We don't know what T is.
    }
                                     // Closed type here: T is Food.
    public class ParkPicnicBlanket : PicnicBlanket<Food> {
    }
