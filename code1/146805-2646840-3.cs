    internal bool PingServer()
    {
        bool netOK = false;
        // 164.110.12.144 is current server address for server: nwhqsesan02
    
        byte[] AddrBytes = new byte[] { 164, 110, 12, 144 }; // byte array for server address.
        using (System.Net.NetworkInformation.Ping png = new System.Net.NetworkInformation.Ping())
        {
            System.Net.IPAddress addr;
            // Sending ping to a numeric byte address has the best change of 
            // never causing en exception, whether network connected or not.
            addr = new System.Net.IPAddress(AddrBytes);
            try
            {
                netOK = (png.Send(addr, 1500, new byte[] { 0, 1, 2, 3 }).Status == IPStatus.Success);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
                netOK = false;
            }
            return netOK;
        }
    }
