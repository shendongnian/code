    //ShellViewModel:
    public override void TryClose(bool? dialogResult = null)
    {
        base.TryClose(dialogResult);
        //...
        foreach (var item in Items)
            item.TryClose();
    }
