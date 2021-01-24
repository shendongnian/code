    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.TabLayoutView);
        var set = this.CreateBindingSet<TabLayoutViewController, TabLayoutViewModel>();
        set.Apply();
        if (bundle == null)
        {
            ViewModel.ShowInitialViewModelsCommand.Execute();
        }
    }
