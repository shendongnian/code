    // ShellViewModel
    public override void TryClose(bool? dialogResult = default(bool?))
    {
        _disposeList.Dispose();
        
        while (Items.Any())
           DeactivateItem(Items.First(), true);
        base.TryClose(dialogResult);
        Application.Current.Shutdown();
    }
