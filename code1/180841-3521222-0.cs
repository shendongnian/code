    //In Login.aspx
    Context.Items["userName"] = myValue;
    Server.Transfer("Account.aspx");
    //In Account.aspx
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostback)
       {
          if (UserName == null)
          {
             UserName == Context.Items["userName"];
          }
          if (UserName == null)
          {
             Server.Transfer("Login.aspx");
          }
       }
    }
        private String UserName
        {
            get
            {
                if (ViewState["UserName"] != null)
                {
                    return ViewState["UserName"].ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["UserName"] = value;
            }
        }
