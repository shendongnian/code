    public class Product
    {
      private idType id;
      public string Name
      {
        get
        {
          return Localizer.Instance.GetLocalString(id, "Name");
        }
      }
    }
