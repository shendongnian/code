    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string ipAddress;
                var newConnectionString = SwapConnectionStringDNSWithIP("Server=google.com;Database=myDataBase;Uid=myUsername;Pwd=myPassword;", out ipAddress);
                Console.WriteLine(ipAddress);
                Console.WriteLine(newConnectionString);
                Console.ReadKey(true);
            }
    
            public static string SwapConnectionStringDNSWithIP(string connectionString, out string ipAddress)
            {
                ipAddress = null;
                if (string.IsNullOrEmpty(connectionString))
                    return null;
                var dict = new Dictionary<string, string>();
                var pParts = connectionString.Split(';');
                foreach (var part in pParts)
                {
                    if (part.IndexOf('=') == -1)
                        break;
                    var sParts = part.Split('=');
                    if (sParts.Length != 2)
                        break;
                    string key = sParts[0].ToLower().Trim();
                    string value = sParts[1];
                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, value);
                    }
                }
                var server = dict.ContainsKey("server") ? dict["server"] : null;
                if (server == null)
                    return null;
    
                var ret = Dns.GetHostEntry(server);
                var addresses = ret.AddressList.Select(a => a.GetAddressBytes()).ToArray();
                if (addresses != null && addresses.Length > 0)
                {
                    ipAddress = string.Join(".", addresses[0]);
                    dict["server"] = ipAddress;
                    var newConnectionString = string.Join(string.Empty, dict.Keys.Select(k => k + "=" + dict[k] + ";").ToArray());
                    return newConnectionString;
                }                      
                return null;
            }
        }
    }
