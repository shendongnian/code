    enum AcquireResult
    {
        OK = 0,
        InitFailed = 1,
        DeviceIDFailed = 2,
        CapabilityFailed = 3,
        UserInterfaceError = 4
    }
    private void StartScan()
    {
        if (!_msgFilter)
        {
            _parent.Enabled = false;
            _msgFilter = true;
            Application.AddMessageFilter(this);
        }
        AcquireResult ar = _twain.Acquire();
        if (ar != AcquireResult.OK)
        {
            EndingScan();
            switch (ar)
            {
                case AcquireResult.CapabilityFailed:
                    throw new Exception("Scanner capability setup failed");
                case AcquireResult.DeviceIDFailed:
                    throw new Exception("Unable to determine device identity");
                case AcquireResult.InitFailed:
                    throw new Exception("Scanner initialisation failed");
                case AcquireResult.UserInterfaceError:
                    throw new Exception("Error with the Twain user interface");
                default:
                    throw new Exception("Document scanning failed");
            }
        }
    }
