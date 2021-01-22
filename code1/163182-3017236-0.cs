    using System.Management;
    
    public uint CPUSpeed()
    {
      ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'");
      uint sp = (uint)(Mo["CurrentClockSpeed"]);
      Mo.Dispose();
      return sp;
    }
