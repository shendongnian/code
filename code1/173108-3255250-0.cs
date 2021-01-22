    public static class Extensions
    {
       public static T FindControl<T>(this Control parent, string id) where T : Control
       {
          return item.FindControl(id) as T;
       }
    }
