    bool AreEquivalent(IPAddress ip6addr, IPAddress ip4addr)
    {
      byte[] ip6bytes = ip6addr.GetBytes();
      byte[] ip4bytes = ip4addr.GetBytes();
      for (int i = 0; i < 10; i++)
      {
         if (ip6bytes[i] != 0)
           return false;
      }
      for (int i = 0; i < 4; i++)
      {
         if (ip6bytes[i + 12] != ip4bytes[i])
            return false;
      }
      return true;
    }
