    AResponse aResp = null;
    BResponse bResp = null;
    using (ServiceAProxy proxyA = new ServiceAProxy())
    {
       aResp = proxyA.DoServiceAWork();
       using (ServiceBProxy proxyB = new ServiceBProxy())
       {
          bResp = proxyB.DoOtherork(aResp);
       }
    }
    return bResp;
