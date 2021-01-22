    protected void Page_Load(object sender, EventArgs e)
    {
        FormsIdentity cIdentity = Page.User.Identity as FormsIdentity;
        if (cIdentity != null)
        {
            this.hdnStreetCred.ID = FormsAuthentication.FormsCookieName;
            this.hdnStreetCred.Value = FormsAuthentication.Encrypt(((FormsIdentity)User.Identity).Ticket);
        }
    }
