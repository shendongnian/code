    IQuery query = session.GetNamedQuery("UserSession_Save");
    query.SetInt32("UserID", userID);
    query.SetString("CookieID", cookieID);
    query.SetString("Controller", controller);
    query.SetString("Action", action);
    
    query.UniqueResult();
