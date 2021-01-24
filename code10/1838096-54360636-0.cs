     protected void Page_Load(object sender, EventArgs e)
     {
           if(!Page.IsPostBack)   
           {
            if (Session["UserEmployee"] != null)
            {
                userEmployeeNumber = Convert.ToString(Session["UserEmployee"]);
                GetUserData();
                ShowNotification("Welcome! Mr/Mrs " + EmployeeID.UserName.ToString() + "", WarningType.Success);
            }
          }
     }
