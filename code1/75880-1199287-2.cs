    protected override void OnInit(EventArgs e)
    {
        //load the controls before ViewState is loaded
        base.OnInit(e);
        for (int i = 0; i < 3; i++)
        {
            CheckBox cb = new CheckBox();
            cb = new CheckBox();
            cb.ID = "KeyWord" + i.ToString();
            cb.Text = "Key Word"
            MyPlaceHolder.Controls.Add(new CheckBox());
        }
    }
    //this could also be a button click event perhaps?
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (Page.IsPostBack)
        {
            //read the checkbox values
            foreach(CheckBox control in MyPlaceHolder.Controls)
            {
                bool isChecked = control.Checked;
                string keyword = control.Text;
                //do something with these two values
            }
        }
    }
