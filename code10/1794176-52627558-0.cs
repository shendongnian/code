    ContentPlaceHolder cph = Master.FindControl("MainContent") as ContentPlaceHolder;
    
    for (int i = 1; i < 9; i++)
    {
        String butt = String.Format("Button{0}", i);
        var btn = cph.FindControl(butt);
        btn.Visible = false;
    }
