    public void Dispose()
    {
        var isSuccess = WinUsbApiCalls.WinUsb_Free(Handle);
        WindowsDeviceBase.HandleError(isSuccess, "Interface could not be disposed");
    }
