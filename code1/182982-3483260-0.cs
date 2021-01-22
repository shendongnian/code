    byte[] ip = ipAddressControl1.GetAddressBytes();
    if (ip[3] != 255)
    {
        ip[3] = (byte)(++ip[3]);
    }
    else
    {
        ip[2] = (byte)(++ip[2]);
        ip[3] = (byte)0;
    }
    IPAddress ipAddress1 = new IPAddress(ip);
    MessageBox.Show(ipAddress1.ToString());
