    public enum PriceCategories
    {
      // ...
    }
    public static readonly DependencyProperty PriceCatProperty =
      DependencyProperty.Register("PriceCat", typeof(PriceCategories),
      typeof(CustControl),  new PropertyMetadata(PriceCategories.First));
    };  // <-- this is probably closing the containing class
