    void Page_Load(object o, EventArgs e)
    {
        _adminControls.Visibile = IsAdmin();
    }
    void Login_Clicked(object o, EventArgs e)
    {
        DoLogin();
    }
