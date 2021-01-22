    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (User.Identity.IsAuthenticated)
            ViewStateUserKey = User.Identity.Name;
    }
