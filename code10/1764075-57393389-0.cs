    protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
    {
        base.OnElementChanged(e);
        if (e.NewElement != null)
        {
            var toolbarId = Context.Resources.GetIdentifier("toolbar", "id", Context.PackageName);
            var toolbar = this.FindViewById(toolbarId) as Android.Support.V7.Widget.Toolbar;
            if (toolbar != null) toolbar.SetContentInsetsAbsolute(0, 0);
        }
    }
