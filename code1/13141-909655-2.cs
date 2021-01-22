    private void LoadDataTypeEditorControl(string userControlName, Control containerControl)
    {
        using (UserControl myControl = (UserControl) LoadControl(userControlName))
        {
            containerControl.Controls.Clear();
    
            string userControlID = userControlName.Split('.')[0];
            myControl.ID = userControlID.Replace("/", "").Replace("~", "");
            containerControl.Controls.Add(myControl);
        }
        this.CurrentUserControl = userControlName;
    }
