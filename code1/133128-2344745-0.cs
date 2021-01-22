    protected Hashtable AttemptCount
    {
      get
      {
        if (Session["AttemptCount"] == null)
          Session["AttemptCount"] = new Hashtable();
        return Session["AttemptCount"] as Hashtable; 
      }
    }
