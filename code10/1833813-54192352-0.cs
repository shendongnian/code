            List<NContainer> nList = new List<NContainer>();
            nList.Add(new NContainer { _HostFqdn = "ab1.corp.com", _HostIp = "192.168.0.2", _Severity = 1, _Issue = "Check 1", _ProtoPort = "TCP_80" });
            nList.Add(new NContainer { _HostFqdn = "ab2.corp.com", _HostIp = "192.168.0.3", _Severity = 2, _Issue = "Check 2", _ProtoPort = "TCP_81" });
            nList.Add(new NContainer { _HostFqdn = "ab3.corp.com", _HostIp = "192.168.0.4", _Severity = 1, _Issue = "Check 2", _ProtoPort = "TCP_82" });
            nList.Add(new NContainer { _HostFqdn = "ab4.corp.com", _HostIp = "192.168.0.5", _Severity = 3, _Issue = "Check 1", _ProtoPort = "TCP_80" });
            nList.Add(new NContainer { _HostFqdn = "ab5.corp.com", _HostIp = "192.168.0.6", _Severity = 3, _Issue = "Check 5", _ProtoPort = "TCP_443" });
            nList.Add(new NContainer { _HostFqdn = "ab6.corp.com", _HostIp = "192.168.0.7", _Severity = 4, _Issue = "Check 1", _ProtoPort = "TCP_80" });
            IEnumerable<NContainer> query = from NContainer vulns in nList
                                     orderby vulns._Issue
                                     where vulns._Severity >= 1
                                     select vulns;
            Console.WriteLine("Group by _Issue");
            var prevIssue = "";
            bool first = true;
            foreach (var vuln in query)
            {
                if (prevIssue != vuln._Issue)
                {
                    if (first)
                        first = false;
                    else
                        Console.WriteLine("\n");
                    Console.WriteLine("\t{0}", vuln._Issue);
                    Console.Write("\t");
                    prevIssue = vuln._Issue;
                }
                Console.Write("{0} {1}  ", vuln._HostIp, vuln._ProtoPort);
            }
