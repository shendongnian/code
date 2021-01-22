    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (string key in Request.Form.AllKeys)
        {
             Response.Write(key + " :: " + Request.Form[key] + "<br/>");
        }
    }
