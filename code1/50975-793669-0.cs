    class Product
    {
      string LocalizedName 
      { 
        get { return AllProductNames[Thread.CurrentThread.CurrentCulture.LCID]; }
      }
      IDictionary<int, string> AllProductNames { get; private set; }
    }
