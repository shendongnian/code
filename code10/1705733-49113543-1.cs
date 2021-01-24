    public async Task<IPStatus> PingHostAddressAsync(string HostAddress, int timeout)
    {
        //(...)
        iReplay = await iPing.SendPingAsync(HostAddress,
                                            timeout,
                                            buffer,
                                            new PingOptions(64, false));
        //(...)
    }
