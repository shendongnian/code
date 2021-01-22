    void Page_Load(object o, EventArgs e)
    {
        // Move binding code, etc to a BindData function and only call it if !IsPostBack
        if (!IsPostBack)
        {
            BindData();
        }
    }
    void BindData()
    {
        _adminControls.Visibile = IsAdmin();
    }
    void Login_Clicked(object o, EventArgs e)
    {
        DoLogin();
        BindData(); // Call BindData function after login
    }
