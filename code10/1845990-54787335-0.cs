    protected override void ViewIsAppearing(object sender, EventArgs e)
    {
        base.ViewIsAppearing(sender, e);
        _previousModel = (FirstPageModel)PreviousPageModel;
    }
