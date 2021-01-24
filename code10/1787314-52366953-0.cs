      public List<Popup> ActivePopups = new List<Popup>();
      public void AddActivePopup(ref Popup ActivePopup)
      {
        try
          {
            if (ActivePopup.IsOpen == true)
                ActivePopups.Add(ActivePopup);
          }
        catch (Exception ex)
          {
            throw ex;
          }
       } 
