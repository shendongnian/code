    protected RegionEnum _Region;
    [Category("Custom Properties")]
    [DefaultValue(RegionEnum.None)]
    [Description("Select a value from the dropdown list.")]
    [Browsable(true)]
    [WebPartStorage(Storage.Shared)]
    [FriendlyName("Region")]
    public RegionEnum Region
    {
        get
        {
            return _Region;
        }
        set
        {
            _Region = value;
        }
    }
