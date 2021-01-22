    protected virtual void OnUsbConnected(object Sender, EventArrivedEventArgs Arguments)
    {
        PropertyData TargetInstanceData = Arguments.NewEvent.Properties["TargetInstance"];
        if (TargetInstanceData != null)
        {
            ManagementBaseObject TargetInstanceObject = (ManagementBaseObject)TargetInstanceData.Value;
            if (TargetInstanceObject != null)
            {
                string dependent = TargetInstanceObject.Properties["Dependent"].Value.ToString();
                string deviceId = dependent.Substring(dependent.IndexOf("DeviceID=") + 10);
                // device id string taken from windows device manager
                if (deviceId = "USB\\\\VID_0403&PID_6001\\\\12345678\"")
                {
                    // Device is connected
                }
            }
        }
    }
        
