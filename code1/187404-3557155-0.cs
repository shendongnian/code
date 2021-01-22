    string space = Server.HtmlDecode("&nbsp;");
    
    for (int i = 0; i < depth; i++)
    {
        menuTxt = space + menuTxt;
    }
