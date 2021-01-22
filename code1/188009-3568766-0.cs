        ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'");
        object o = Mo["Architecture"];
        UInt16 sp = (UInt16)(o);
        if (sp == 0)
        {
            //86
        } else if (sp == 9)
        {
            //64
        }
        Mo.Dispose();
