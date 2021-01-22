    private string BuildUdh(byte messageId, byte partCount, byte partId)
    {
        var udg = new byte[6];
        udg[0] = 0x05;      // Overall length of UDH
        udg[1] = 0x00;      // IE Concat 
        udg[2] = 0x03;      // IE parameter Length
        udg[3] = messageId;
        udg[4] = partCount;
        udg[5] = partId;
    [..]
