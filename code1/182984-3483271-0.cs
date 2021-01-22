    byte[] ip = ipAddressControl1.GetAddressBytes();
    ip[3] = (byte)(++ip[3]);
    if (ip[3] == 0) {
        ip[2] = (byte)(++ip[2]);
        if (ip[2] == 0) {
            ip[1] = (byte)(++ip[1]);
            if (ip[1] == 0) {
                ip[0] = (byte)(++ip[0]);
            }
        }
    }
