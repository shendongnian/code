    using System.Management;
    public static void Main()
    {
         GetPortInformation();
    }
    public string GetPortInformation()
        {
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();           
            foreach (ManagementObject property in Ports)
            {
                var name = property.GetPropertyValue("Name");               
                if (name != null && name.ToString().Contains("USB") && name.ToString().Contains("COM"))
                {
                    var portInfo = new SerialPortInfo(property);
                    //Thats all information i got from port.
                    //Do whatever you want with this information
                }
            }
            return string.Empty;
        }
