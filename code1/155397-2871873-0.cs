    private void GetSerialPort()
    {
  
        try
        {
            ManagementObjectSearcher searcher = 
                new ManagementObjectSearcher("root\\CIMV2", 
                "SELECT * FROM Win32_PnPEntity"); 
            foreach (ManagementObject queryObj in searcher.Get())
            {
                if (queryObj["Caption"].ToString().Contains("(COM"))
                {
                    Console.WriteLine("serial port : {0}", queryObj["Caption"]);
                }
            }
        }
        catch (ManagementException e)
        {
            MessageBox.Show( e.Message);
        }
    }
