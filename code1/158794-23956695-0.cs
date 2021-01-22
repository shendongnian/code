        static Joystick[] joystick = new Joystick[1];
    const int minimum_value = -1000;//your values goes here
    const int maximum_value = 1000;//your values goes here
    public test()
    {
        DirectInput USBJoystick = new DirectInput();
        IList<DeviceInstance> device = null;//to get the joysticks
        device = USBJoystick.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly);
        if (device.Count == 1)
            joystick[0] = new Joystick(USBJoystick, device[0].InstanceGuid);
        foreach (DeviceObjectInstance deviceObject in joystick[0].GetObjects())
        {
            if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                joystick[0].GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(minimum_value, maximum_value);
        }
    }
