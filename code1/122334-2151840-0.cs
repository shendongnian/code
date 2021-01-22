    // first gather the email address that is going to be associated with this user as
    // their gravatar.
    // once you have gathered the email address send it to a private method that
    // will return the correct url format.
    protected void uxAssocateAvatar_Click(object sender, EventArgs e)
    {
	if (Page.IsValid)
	{
		string emailAddress = uxEmailAddress.Text;
		try
		{
			Profile.Avatar = GetGravatarUrl(emailAddress);
			Profile.Save();
			Response.Redirect("Settings.aspx", true);
		}
		catch (Exception ex)
		{
			ProcessException(ex, Page);
		}
	}
    }
    // use this private method to hash the email address, 
    // and then create the url to the gravatar service.
    private string GetGravatarUrl(string dataItem)
    {
        string email = dataItem;
        string hash =
            System.Web.Security.FormsAuthentication.
            HashPasswordForStoringInConfigFile(email.Trim(), "MD5");
        hash = hash.Trim().ToLower();
        string gravatarUrl = string.Format(
           "http://www.gravatar.com/avatar.php?gravatar_id={0}&rating=G&size=100",
            hash);
        return gravatarUrl;
    }
    // on the page where an avatar will be displayed, 
    // just drop in an asp.net image control with a default image.
    <asp:Image ID="uxAvatar" runat="server" ImageUrl="~/images/genericProfile.jpg"
	AlternateText="" CssClass="profileAvatar" BorderWidth="1px"/>
    // and on page_load or something like that, 
    // check to see if the profile's avatar property is set	
    if (Profile.Avatar != null)
    {
        uxAvatar.ImageUrl = Profile.Avatar;
    }
    // by default the profile's avatar property will be null, and when a user decides
    // that they no longer want an avatar, the can de-associate it by creating a null 
    // property which can be checked against 
    // to see if they have one or don't have one.
    protected void uxRemoveAvatar_Click(object sender, EventArgs e)
    {
        Profile.Avatar = null;
        Profile.Save();
        Response.Redirect("Settings.aspx", true);
    }
