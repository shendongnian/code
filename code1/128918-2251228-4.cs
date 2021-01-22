    public class MyConverter : IValueConverter
    {
      public object Convert(object value, ...)
      {
        return
          from item in (IEnumerable<MyItem>)value
          group item by item.Type into g
          select new { Type = g.Key, Items = g }
      }
      ...
    }
