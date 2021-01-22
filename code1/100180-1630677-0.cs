    public int Function()
    {
      int leadID = 0;
      try
      {
        int leadID = (int)Session["SelectedLeadID"];
      }
      catch (Exception ex)
      {
        ...
      }
      return leadID
    }
