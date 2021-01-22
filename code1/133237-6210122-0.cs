    public static class ExtensionMethods
    {
      public static int IndexOf(
        this MyApp.BingRoute.ItineraryItem[] II, 
        Turnwise.BingRoute.ItineraryItem ii)
      {
        return Array.IndexOf<Turnwise.BingRoute.ItineraryItem>(II, ii);
      }
    }
