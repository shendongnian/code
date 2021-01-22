	PeerName myPeer = new PeerName("MySecurePeer", PeerNameType.Secured);
	PeerNameResolver resolver = new PeerNameResolver();
          
	PeerNameRecordCollection results = resolver.Resolve(myPeer);
	Console.WriteLine("{0} Peers Found:", results.Count.ToString());
	int i = 1;
	foreach (PeerNameRecord peer in results)
	{
	    Console.WriteLine("{0} Peer:{1}", i++, peer.PeerName.ToString());
	    foreach (IPEndPoint ip in peer.EndPointCollection)
	    {
	        Console.WriteLine("\t Endpoint: {0}", ip.ToString());
	    }
	}
