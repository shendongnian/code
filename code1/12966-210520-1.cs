    var service = new Mono.Zeroconf.RegisterService {
                    Name = "Use Me for Stuff",
                    RegType = "_daap._tcp",
                    ReplyDomain = "local.",
                    Port = 0024200,
                    TxtRecord = new Mono.Zeroconf.TxtRecord {
                                {"I have no idea what's going on", "true"}}
                  };
    service.Register();
    var browser = new Mono.Zeroconf.ServiceBrowser();
    browser.ServiceAdded +=
        delegate(object o, Mono.Zeroconf.ServiceBrowseEventArgs args) {
            Console.WriteLine("Found Service: {0}", args.Service.Name);
            args.Service.Resolved +=
                delegate(object o, Mono.Zeroconf.ServiceBrowseEventArgs args) {
                    var s = args.Service;
                    Console.WriteLine(
                        "Resolved Service: {0} - {1}:{2} ({3} TXT record entries)",
                        s.FullName, s.HostEntry.AddressList[0], s.Port, s.TxtRecord.Count);
              };
            args.Service.Resolve();
        };
    browser.Browse("_daap._tcp", "local");
