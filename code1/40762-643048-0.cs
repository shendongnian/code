    void Test(Control control)
    {
        if (control is TextBox)
        {
           ((TextBox)control).Text = "test";
        }
    }
    void Test<T>(T control) where T : Control
    {
        if (control is TextBox)
        {
            ((TextBox)control).Text = "test";
        }
    }
