    object id = Session["Co_ID"];
    if (id == null)
    {
        id = Session["Co_ID"] = LoadCoIdFromSomewhere();
    }
    string Teststr = id.ToString();
