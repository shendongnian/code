    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "UserControl - 1 button clicked!";
        var ctrl = LoadControl("~/UserCtrl2.ascx");
        ctrl.ID = "ucUserCtrl2";
        PlaceHolder2.Controls.Add(ctrl);
    
        this.SecondControlLoaded = true; // This flag saves to ViewState that your control was loaded.
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var ctrl = LoadControl("~/UserCtrl1.ascx");
        ctrl.ID = "ucUserCtrl1";
        PlaceHolder1.Controls.Add(ctrl);
        if (this.SecondControlLoaded)
        {
            var ctrl = LoadControl("~/UserCtrl2.ascx");
            ctrl.ID = "ucUserCtrl2";
            PlaceHolder2.Controls.Add(ctrl);
        }
    }
