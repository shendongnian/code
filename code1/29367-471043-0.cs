    protected void Page_Init(object sender, EventArgs e)
    {
        string m_QueryStringValue = Request.QueryString.Get("action") ?? "";
        if (m_QueryStringValue.ToLower() == "send")
        {
            if ( (Session["to"] as List<string>) != null) 
            {
                this.SendPageByMail();
            }
            else
            {
                Session.Add("AddressToSend", Request.RawUrl);
                Response.Redirect("~/chooseRecipients.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest()
            }
        }
    }
