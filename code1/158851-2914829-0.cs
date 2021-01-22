    if(Session["keyName"] != null)
    {
      Session["permitError"] = querysting;
    }
    else
    {
       Session.Add("keyName", value);
    }
