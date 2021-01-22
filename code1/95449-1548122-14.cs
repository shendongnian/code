    static void Main(string[] args)
    {
        List<IPEndPoint> endPoints = new List<IPEndPoint>(
            new IPEndPoint[]{
                new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80),
                new IPEndPoint(IPAddress.Parse("69.59.196.211"), 80),
                new IPEndPoint(IPAddress.Parse("74.125.45.100"), 80)
            });
        using (DatabaseFile dbf = new DatabaseFile("iptable.txt"))
        {
            foreach (IPEndPoint endPoint in endPoints)
                dbf.Append(new Record { 
                    Address = endPoint.Address, 
                    Port = endPoint.Port });
            Record stackOverflow = dbf.Locate(r => 
                Dns.GetHostEntry(r.Address)
                    .HostName.Equals("stackoverflow.com")).FirstOrDefault();
            if (stackOverflow != null)
                dbf.Delete(stackOverflow);
            Record google = dbf.Locate(r =>
                r.Address.ToString() == "74.125.45.100").First();
            google.Port = 443;
            dbf.Update(google);
            foreach(Record http in dbf.Locate(r => 
                !r.Deleted && r.Port == 80))
                Console.WriteLine(http.ToString());
        }
        Console.ReadLine();
    }
