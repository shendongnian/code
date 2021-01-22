    [AcceptVerbs(HttpVerbs.Post)]
    public ViewResult Index(string btnCompose, string btnMarkAsRead, string btnDelete, FormCollection formCollection)
    {
      if (btnCompose != null)
      {
        //Return the compose View
      }
      else if (btnMarkAsRead != null)
      {
        // Mark As Read was clicked, handle appropriately
        //Loop through every key in the collection looking for stuff that starts with chk
        foreach (string key in formCollection.Keys)
        {
          if (key.StartsWith("chk"))
          {
            //Do Mark Read Here
          }
        }
      }
      else if (btnDelete != null)
      {
       //Loop through every key in the collection looking for stuff that starts with chk
        foreach (string key in formCollection.Keys)
        {
          if (key.StartsWith("chk"))
          {
            //Do Mark Delete Here
          }
        }
      }
    }
