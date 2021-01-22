    /// <summary>
    		/// Get the MX from the domain address.
    		/// </summary>
    		public static string getMXrecord(string domain)
    		{
    			domain = domain.Substring(domain.IndexOf('@') + 1);
    			string LocalDNS = GetDnsAdress().ToString();
    			Console.WriteLine("domain: " + domain);
    			
    			// resolv the authoritative domain (type=2)
    			C_DNSquery DnsQry = new C_DNSquery(LocalDNS, domain, 2);
    			Thread t1 = new Thread(new ThreadStart(DnsQry.doTheJob));
    			t1.Start();
    			int timeout = 20;
    			while ((timeout > 0) & (!DnsQry.Done)) {
    				Thread.Sleep(100);
    				timeout--;
    			}
    			if (timeout == 0) {
    				if (DnsQry.udpClient != null) {
    					DnsQry.udpClient.Close();
    				}
    				t1.Abort();
    				DnsQry.Error = 100;
    			}
    
    			string[] ns1;
    			string MyNs = "";
    			if (DnsQry.Error == 0) {
    				ns1 = DnsQry.result[0].Split(',');
    				MyNs = ns1[4];
    				t1.Abort();
    			} else {
    				t1.Abort();
    				MyNs = LocalDNS;
    			}
    			
    			// Resolve MX (type = 15)
    			DnsQry = new C_DNSquery(MyNs, domain, 15);
    			Thread t2 = new Thread(new ThreadStart(DnsQry.doTheJob));
    			t2.Start();
    			timeout = 20;
    			string TTL = "";
    			string MXName = "";
    			Int32 preference = 9910000;
    			while ((timeout > 0) & (!DnsQry.Done)) {
    				Thread.Sleep(100);
    				timeout--;
    			}
    			if (timeout == 0) {
    				if (DnsQry.udpClient != null) {
    					DnsQry.udpClient.Close();
    				}
    				t2.Abort();
    				DnsQry.Error = 100;
    			}
    			if (DnsQry.Error == 0) {
    				
    				if (DnsQry.result.Count == 1) {
    					string[] ns2 = DnsQry.result[0].Split(',');
    					MXName = ns2[5];
    					TTL = ns2[3];
    					preference = Int32.Parse(ns2[4]);
    					Console.WriteLine("domaine: {0} MX: {1} time: {2} pref: {3} ttl: {4}", domain.Substring(domain.IndexOf('@') + 1), MXName, 
    						DateTime.Now, preference, TTL);
    			
    			
    				} else {
    					for (int indns = 0; indns <= DnsQry.result.Count - 1; indns++) {
    						string[] ns2 = DnsQry.result[indns].Split(',');
    						if (Int32.Parse(ns2[4]) < preference) {
    							MXName = ns2[5];
    							TTL = ns2[3];
    							preference = Int32.Parse(ns2[4]);
    Console.WriteLine("domain: {0} MX: {1} time: {2} pref: {3} ttl: {4}", domain.Substring(domain.IndexOf('@') + 1), MXName, 
    								DateTime.Now, preference, TTL);
    			
        						}
    					}
    				}
    			}
    			return MXName;
    		}
    		
