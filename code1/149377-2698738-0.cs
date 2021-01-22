    public static class Extension{
    
      public static T FindControl<T>(this Control control, string id) 
       where T : Control{
           return control.FindControl(id) as T;
      }
    
    }
