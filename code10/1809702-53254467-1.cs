    private ReadBarCodeInMenu _readBarCodeInMenu;
    public ContainerInquiry(ReadBarCodeInMenu readBarCodeInMenu)
    {
        InitializeComponent();
        _readBarCodeInMenu = readBarCodeInMenu;
    }
    private void logoutBtn_Click(object sender, EventArgs e)
    {
        _readBarCodeInMenu.btnContainerInquiry.Enabled = true; 
    }
