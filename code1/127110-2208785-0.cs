    public T FindControl<T>(string id) where T : Control
       {
           return FindControl<T>(Page, id);
       }
       
       public static T FindControl<T>(Control startingControl, string id) where T : Control
       {
           // this is null by default
           T found = default(T);
      
          int controlCount = startingControl.Controls.Count;
      
          if (controlCount > 0)
          {
              for (int i = 0; i < controlCount; i++)
              {
                  Control activeControl = startingControl.Controls[i];
                  if (activeControl is T)
                  {
                     found = startingControl.Controls[i] as T;
                      if (string.Compare(id, found.ID, true) == 0) break;
                      else found = null;
                  }
                  else
                  {
                      found = FindControl<T>(activeControl, id);
                      if (found != null) break;
                  }
              }
          }
          return found;
      }  
