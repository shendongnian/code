        public static void SetAsPrimaryMonitor(uint id)
        {
            var device = new DISPLAY_DEVICE();
            var deviceMode = new DEVMODE();
            device.cb = Marshal.SizeOf(device);
            NativeMethods.EnumDisplayDevices(null, id, ref device, 0);
            NativeMethods.EnumDisplaySettings(device.DeviceName, -1, ref deviceMode);
            var offsetx = deviceMode.dmPosition.x;
            var offsety = deviceMode.dmPosition.y;
            deviceMode.dmPosition.x = 0;
            deviceMode.dmPosition.y = 0;
            NativeMethods.ChangeDisplaySettingsEx(
                device.DeviceName, 
                ref deviceMode, 
                (IntPtr)null, 
                (ChangeDisplaySettingsFlags.CDS_SET_PRIMARY | ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY | ChangeDisplaySettingsFlags.CDS_NORESET), 
                IntPtr.Zero);
            device = new DISPLAY_DEVICE();
            device.cb = Marshal.SizeOf(device);
            // Update remaining devices
            for (uint otherid = 0; NativeMethods.EnumDisplayDevices(null, otherid, ref device, 0); otherid++)
            {
                if (device.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop) && otherid != id)
                {
                    device.cb = Marshal.SizeOf(device);
                    var otherDeviceMode = new DEVMODE();
                    
                    NativeMethods.EnumDisplaySettings(device.DeviceName, -1, ref otherDeviceMode);
                    otherDeviceMode.dmPosition.x -= offsetx;
                    otherDeviceMode.dmPosition.y -= offsety;
                    NativeMethods.ChangeDisplaySettingsEx(
                        device.DeviceName,
                        ref otherDeviceMode,
                        (IntPtr)null,
                        (ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY | ChangeDisplaySettingsFlags.CDS_NORESET),
                        IntPtr.Zero);
                }
                device.cb = Marshal.SizeOf(device);
            }
            // Apply settings
            NativeMethods.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr)null, ChangeDisplaySettingsFlags.CDS_NONE, (IntPtr)null);
        }
