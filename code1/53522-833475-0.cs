    IFolderOrItem SelectedItem { get; set; }
    ...
    public void SomeMagicMethod()
    {
        this.SelectedItem = (IFolderOrItem)GetMagicDocument();
        // not **so** bad
    }
