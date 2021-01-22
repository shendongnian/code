    protected RegionEnum _Region;
    [Category("Custom Properties")]
    [DefaultValue(RegionEnum.None)]
    [WebPartStorage(Storage.Shared)]
    [FriendlyName("Region")]
    [Description("Select a value from the dropdown list.")]
    [Browsable(true)]
    public RegionEnum Region
    {
        get { return _Region; }
        set { _Region = value; }
    }
