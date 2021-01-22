    public class ShopSettings
    {
      public static ShopSettings Instance
      {
        get
        {
          if (_Instance == null)
          {
            _Instance = new ShopSettings();
          }
          return _Instance;
        }
      }
    }
