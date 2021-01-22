		var a = Create();
		if (System.Runtime.Remoting.RemotingServices.IsTransparentProxy(a))
		{
			var c = System.Runtime.Remoting.RemotingServices.GetObjRefForProxy(a);
			var ad = c.ChannelInfo.ChannelData[0];
			var propDomainId = ad.GetType().GetProperty("DomainID", BindingFlags.NonPublic | BindingFlags.Instance);
			var DomainID = propDomainId.GetValue(ad,null);
		}
