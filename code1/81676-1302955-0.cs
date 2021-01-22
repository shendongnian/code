    public Visibility ContextMenuVisibility
    {
        get { return (this.ShowContextMenu) ? Visibility.Visible : Visibility.Collapsed; }
    }
    public bool ShowContextMenu { get; set; }
