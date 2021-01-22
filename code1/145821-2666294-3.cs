            public DeviceController( )
        {
            EventDispatcher<DEVICE_ACTION_REQUEST>.Subscribe(DEVICE_ACTION_REQUEST.LoadAxisDefaults, (s, e) =>
                {
                    InControlThread.Invoke(this, () =>
                    {
                        ReadConfigXML(s, (EventArgs<string>)e);
                    });
                });
        }
