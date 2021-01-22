    public class TopLevelItemComparer : IComparer<topLevelItem>
    {
      public int Compare( topLevelItem x, topLevelItem y )
      {
          return DateTime.Parse(x.subLevelItem.DeliveryTime).CompareTo(
                 DateTime.Parse(y.subLevelItem.DeliveryTime) );
      }
    }
    items.Sort( new TopLevelItemComparer() );
