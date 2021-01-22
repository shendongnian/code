    private void SetCookie()
    {
        HttpCookie cookie = new HttpCookie("cookiename");
        cookie.Expires = DateTime.Now.AddMonths(24);
        cookie.Values.Add("name", Server.UrlEncode(txtName.Text));
        Response.Cookies.Add(cookie);
    }
    
    private void GetCookie()
    {
        HttpCookie cookie = Request.Cookies["cookiename"];
        if (cookie != null)
        {
            txtName.Text = Server.UrlDecode(cookie.Values["name"]);
        }
    }
