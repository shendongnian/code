    protected string image_tag; // add this var in your page class and set it as protected
    ...
    if (!IsPostBack)
    {
    	Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    
    
    	SiteManagementService siteMng = new SiteManagementService();
    	LogedUserDTO logedUser = siteMng.GetLogedUserByUserId(Session["UserLoginID"].ToString().Trim());
    
    	LabelUser.Text = logedUser.FullName + " | " + logedUser.Company.CompanyDesc;
    	image_tag = "<img  src=\"" + siteMng.GetUserImageUrl() + logedUser.ProfileImage + "\"  class='img-avatar'  />";
    	LabelDatetime.Text = DateTime.Now.ToString();
    	Session["UserAccessLevel"] = logedUser.UserGroupId;
    	Session["UserCompanyId"] = logedUser.CompanyId;
    
    	RepeaterMenu.DataSource = siteMng.GetMenuByUserGroup(logedUser.UserGroupId);
    	RepeaterMenu.DataBind();
    
    	LabelMasterFooter.Text = "© 2013 " + ResourceData.CompanyName + ". All rights reserved.";
    
    }
