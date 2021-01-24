    // Iterates all Controllers and delegates the notification data
       // This method can easily be found because every class is “BounceElement” and has an “app” 
       // instance.
       public void Notify(string p_event_path, Object p_target, params object[] p_data)
       {
          BounceController[] controller_list = GetAllControllers();
          foreach(BounceController c in controller_list)
          {
             c.OnNotification(p_event_path,p_target,p_data);
          }
       }
    
       // Fetches all scene Controllers.
       public BounceController[] GetAllControllers() { /* ... */ }
