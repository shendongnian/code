    var sb = new StringBuilder();
    var ip = await device.GetExternalIPAsync();
    
    sb.AppendFormat("\nAdded mapping: {0}:1700 -> 127.0.0.1:1600\n", ip);
    sb.AppendFormat("\n+------+-------------------------------+--------------------------------+------------------------------------+-------------------------+");
    sb.AppendFormat("\n| PROT | PUBLIC (Reacheable)           | PRIVATE (Your computer)        | Descriptopn                        |                         |");
    sb.AppendFormat("\n+------+----------------------+--------+-----------------------+--------+------------------------------------+-------------------------+");
    sb.AppendFormat("\n|      | IP Address           | Port   | IP Address            | Port   |                                    | Expires                 |");
    sb.AppendFormat("\n+------+----------------------+--------+-----------------------+--------+------------------------------------+-------------------------+");
    foreach (var mapping in await device.GetAllMappingsAsync())
    {
    	sb.AppendFormat("\n|  {5} | {0,-20} | {1,6} | {2,-21} | {3,6} | {4,-35}|{6,25}|",
    		ip, mapping.PublicPort, mapping.PrivateIP, mapping.PrivatePort, mapping.Description, mapping.Protocol == Protocol.Tcp ? "TCP" : "UDP", mapping.Expiration.ToLocalTime());
    }
    sb.AppendFormat("\n+------+----------------------+--------+-----------------------+--------+------------------------------------+-------------------------+");
    Console.WriteLine(sb.ToString());
