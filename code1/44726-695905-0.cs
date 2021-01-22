    if (!IsPostback())
    {
      if (Request["book_id"] != null)
      {
        GetExistingBook();
      }
    }
