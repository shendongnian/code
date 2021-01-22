    public override void ItemDeleting(SPItemEventProperties properties)
    {
      if (properties.UserLoginName.ToLower().CompareTo("sharepoint\\system") != 0)
      {
        properties.Cancel = true;
        properties.ErrorMessage = "Some error has occured....";
      }
    }
