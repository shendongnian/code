    //MyStackPanel is a named Control
    foreach (MyUserControl muc in MyStackPanel.Children)
    {
        //ID is public get, private set
        if(muc.ID == 123456)
        {
            muc.ATextBox.Text = "Something Else";
        }
    }
