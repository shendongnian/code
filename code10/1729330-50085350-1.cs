    private void MyUserControl_SomethingHappened(object sender, MyEventArgs e)
    {
        button1.Enabled = e.Enable;
        button2.Enabled = e.Enable;
        ...
        button7.Enabled = e.Enable;
    }
