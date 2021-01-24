    protected bool IsInDesignMode
    {
        get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
    }
    protected BindingList<string> Names;
    protected DsDevice[] Devices;
    public CameraComboBox()
    {
        InitializeComponent();
        if (InDesignMode == false)
        {
            Devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            Names = new BindingList<string>(Devices.Select(d => d.Name).ToList());
            this.DataSource = Names;
        }
        this.DropDownStyle = ComboBoxStyle.DropDownList;
    }
