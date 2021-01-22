    //MyPage.aspx
    void Button_OnClick(object sender, EventArgs e)
    {
    MyUserControl.DataBind(MyTextBox.Text);
    }
    //MyUserControl.ascx
    public void DataBind(string value)
    {
    UpdateView(value);
    }
