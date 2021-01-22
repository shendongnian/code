    protected override void OnInit(EventArgs e)
    {
        //load the controls before ViewState is loaded
        base.OnInit(e);
        for (int i = 0; i < 3; i++)
        {
            MyPlaceHolder.Controls.Add(new CheckBox());
        }
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (Page.IsPostBack)
        {
            //read the checkbox values
            foreach(CheckBox control in MyPlaceHolder.Controls)
            {
                bool isChecked = control.Checked;
                //do something
            }
        }
    }
