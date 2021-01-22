    private void LoadUserControl()
    {
        string controlPath = LastLoadedControl;
        if (!string.IsNullOrEmpty(controlPath))
        {
            PlaceHolder1.Controls.Clear();
            UserControl uc = (UserControl)LoadControl(controlPath);
            uc.ID = "uc";  //Set ID Property here
            PlaceHolder1.Controls.Add(uc);
        }
    }
