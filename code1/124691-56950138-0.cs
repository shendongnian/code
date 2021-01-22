        public string MainDomainFromHost(string host)
        {
            string[] parts = host.Split('.');
            if (parts.Length <= 2)
                return host; // host is probably already a main domain
            if (parts[parts.Length - 1].All(char.IsNumber))
                return host; // host is probably an IPV4 address
            if (parts[parts.Length - 1].Length == 2 && parts[parts.Length - 2].Length == 2)
                return string.Join(".", parts.TakeLast(3)); // this is the case for co.uk, co.in, etc...
            return string.Join(".", parts.TakeLast(2)); // all others, take only the last 2
        }
