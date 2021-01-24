    String idStr = this.Request.QueryString["haberid"];
    if( Int32.TryParse( idStr, NumberStyles.Integer, CultureInfo.InvariantCulture, out Int32 idValue )
    {
        baslik.DataSource = blg.Habers
            .Where( news => news.ID == idValue )
            .ToList();
        baslik.DataBind();    
    }
    else
    {
        // show HTTP 404 error, or HTTP 400 Bad request
    }
