	if (Session["Page"] != null)
	{
		if (Session["SubmittedPayment"] != null)
		{
			//shazbot -- they've already hit submit
			Server.Transfer("default.aspx?logout=true");
		}
		
		Load_Topic1();
		topic1.SelectedValue = IsPostBack ? Request.Form[topic1.UniqueID] : (string)Session["topic1"];
		Load_Section1();
		section1.SelectedValue = IsPostBack ? Request.Form[section1.UniqueID] : (string)Session["section1"];
		Load_Rating1DropDown(); // not sure if you need this???
		rating1DropDown.SelectedValue = IsPostBack ? Request.Form[rating1DropDown.UniqueID] : (string)Session["rating1DropDown"];	
		
		if (Session["Page"].ToString() == "HighSchoolInformation2.aspx")
		{
			Session.Add("Page", "InterestSurvey.aspx");
		}
		else if (Session["Page"].ToString() == "Payment.aspx" || Session["Page"].ToString() == "InterestSurvey.aspx")
		{
			Session.Add("Page", "InterestSurvey.aspx");
		}
		else 
		{
			// you don't actually need to set values before you redirect
			Response.Redirect(Session["Page"].ToString());
		} 
	}
	else
	{
		//they're not logged in, send them back to log in
		Server.Transfer("Default.aspx?logout=true");
	}
