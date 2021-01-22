        public static IPAddress FindNextFree(this IPAddress address)
        {
            IPAddress workingAddress = address;
            Ping pingSender = new Ping();
            while (true)
            {
                byte[] localBytes = workingAddress.GetAddressBytes();
                localBytes[3]++;
                if (localBytes[3] > 254)
                    localBytes[3] = 1;
                workingAddress = new IPAddress(localBytes);
                if (workingAddress.Equals(address))
                    throw new TimeoutException("Could not find free IP address");
                PingReply reply = pingSender.Send(workingAddress, 1000);
                if (reply.Status != IPStatus.Success)
                {
                    return workingAddress;
                }
            }
        }
