    IFolderOrItem SelectedItem { get; set; }
    ...
    public void SomeMagicMethod()
    {
        this.SelectedItem = GetMagicDocument(); // no cast needed
        // not **so** bad
    }
