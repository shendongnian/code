    public DataFromRepoDto GetRouterStatusByMac(string macAddress)
    {
      var nvramdata=_srdbcontext.Nvrams.Where(q => q.SRouter.MacAddress == macAddress).Select(s => new
      {
        s.ConnectionType,
        s.IConfigMacAddress,
        s.LanIPAddress,
        s.LanSubnetNetmask,
        s.DefaultGateway
      }).FirstOrDefault();
      var execdata = _srdbcontext.ExeOuts.Where(q => q.SRouter.MacAddress == macAddress).Select(e => new
      {
        e.BuildInfo,
        e.Uptime,
        e.WANIPAddress,
        e.SubnetMask,
        e.DefaultGateway,
        e.PrimaryDNS,
        e.SecondaryDNS,
        e.LanMacAddress
      }).FirstOrDefault();
      return new DataFromRepoDto
      {
        ConnectionType = nvramdata.ConnectionType,
        IConfigMacAddress = nvramdata.IConfigMacAddress,
        LanIPAddress = nvramdata.LanIPAddress,
        //etc...
      };
        //return result;
    }
    
