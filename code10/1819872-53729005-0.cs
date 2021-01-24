    public static string GetDriveLetter(string serialNum){
        if (serialNum != null)
        {
            var moc = new ManagementObjectSearcher("SELECT SerialNumber, Drive FROM Win32_CDROMDrive");
            foreach(var mo in moc.Get())
            {
                string driveSerial = (string)mo.GetPropertyValue("SerialNumber");
                if (driveSerial != null)
                {
                    if (driveSerial.Trim().Equals(serialNum.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        return (string)mo.GetPropertyValue("Drive");
                    }
                }
            }
        }
        return "Unknown";
    }
