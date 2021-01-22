    public UserControl myCustomControl = new UserControl();
    public Button myDynamicButton = new Button();
    
    protected void btnAddControl_Click(object sender, EventArgs e)
    {
        myCustomControl = (UserControl)Page.LoadControl("SampleControlToLoad.ascx");
        PlaceHolder myPlaceHolder = (PlaceHolder)Page.FindControl("PlaceHolder1");
    
        myPlaceHolder.Controls.Add(myCustomControl);
    }
    protected void btnRemoveControl_Click(object sender, EventArgs e)
    {
        PlaceHolder myPlaceHolder = (PlaceHolder)Page.FindControl("PlaceHolder1");
        if (myPlaceHolder.Controls.Contains(myCustomControl))
        {
            myPlaceHolder.Controls.Remove(myCustomControl);
            myDynamicButton.Dispose();
        }
    }
