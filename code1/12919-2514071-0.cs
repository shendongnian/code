    using (WmiContext context = new WmiContext(@"\\.")) {
      context.ManagementScope.Options.Impersonation = ImpersonationLevel.Impersonate;
      context.Log = Console.Out;
      var dnss = from nic in context.Source<Win32_NetworkAdapterConfiguration>()
              where nic.IPEnabled
              select nic.DNSServerSearchOrder;
      var dns = new List<string>();
      dnss.ToList().ForEach(a => dns.AddRange(a)); }
