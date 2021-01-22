    protected void Page_Load(object sender, EventArgs e)
    {
        string page = "";
        int counter = 0;
        foreach (string s in Request.QueryString.AllKeys)
        {
            if (s != Request.QueryString.Keys[0])
            {
                page += s;
                page += "=" + BinaryCodec.encode(Request.QueryString[counter]);
            }
            else
            {
                page += Request.QueryString[0];
            }
            if (!page.Contains('?'))
            {
                page += "?";
            }
            else
            {
                page += "&";
            }
            counter++;
        }
        page = page.TrimEnd('?');
        page = page.TrimEnd('&');
        Response.Redirect(page);
    }
