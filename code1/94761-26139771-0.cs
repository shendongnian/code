    userControls_DeviceController FAN1;
    userControls_DeviceController FAN2;
    
    protected void Page_Load(object sender, EventArgs e)
    {
       FAN1 = (userControls_DeviceController)LoadControl("~/userControls/DeviceController.ascx");
       saloon.Controls.Add(FAN1);
    
       FAN2 = (userControls_DeviceController)LoadControl("~/userControls/DeviceController.ascx");
       saloon.Controls.Add(FAN2);
    }
