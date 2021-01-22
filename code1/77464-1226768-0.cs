    if (DeviceResponseReceived != null)
    {
        if (DeviceResponseReceived.Target is System.Windows.Forms.Form)
        {
             System.Windows.Forms.Form targetForm = DeviceResponseReceived.Target as System.Windows.Forms.Form;
             targetForm.Invoke(DeviceResponseReceived, new MsgEventArgs<DeviceResponse>(deviceResponse));
        }
    }
