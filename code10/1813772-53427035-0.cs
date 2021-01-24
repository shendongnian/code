    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<UserInfo> allUsersList = Application["AllUsersList"] as List<UserInfo>;
            ....
            ....
            allUsersList.Add(testUser);
            Application["AllUsersList"] = allUsersList;
        }
    }
