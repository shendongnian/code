    public interface IItemContainer
    {
      void SetItem(Sitecore.Data.Items.Item item);
    }
    public static List<T> GetQueryResult<T>(string xpathQuery)
      where T : IItemContainer, new() {
      IList<Sitecore.Data.Items.Item> items = GetAListOfItemsSomehow(xpathQuery);
      
      List<T> result = new List<T>();
      foreach (Sitecore.Data.Items.Item item in items) {
        T obj = new T();
        obj.SetItem(item);
        result.add(obj);
      }
      return result;
    }
