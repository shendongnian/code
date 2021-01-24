    using System;
    using System.Collections.Generic;
    using System.Net;
    
    
    
    class app
    {    
        static void Main()
        {
            List<IPAddress> sortedIPs = new List<IPAddress>();
    
            AddToList(sortedIPs, new byte[4] { 6, 10, 54, 100 });
            AddToList(sortedIPs, new byte[4] { 143, 0, 254, 10 });
            AddToList(sortedIPs, new byte[4] { 48, 0, 0, 1 });
            AddToList(sortedIPs, new byte[4] { 0, 0, 82, 19 });
            AddToList(sortedIPs, new byte[4] { 13, 0, 254, 1 });
            AddToList(sortedIPs, new byte[4] { 63, 93, 4, 111 });
            AddToList(sortedIPs, new byte[4] { 98, 3, 74, 1 });
            AddToList(sortedIPs, new byte[4] { 98, 4, 74, 1 });
            AddToList(sortedIPs, new byte[4] { 98, 3, 14, 1 });
            AddToList(sortedIPs, new byte[4] { 98, 3, 14, 2 });
            AddToList(sortedIPs, new byte[4] { 7, 175, 25, 65 });
            AddToList(sortedIPs, new byte[4] { 46, 86, 21, 91 });
       
            IPAddress findAddress = new IPAddress(new byte[4] { 48, 0, 0, 1 });
    
            int index = sortedIPs.BinarySearch(findAddress, new IPAddressComparer());
    
        }
    
        private static void AddToList(List<IPAddress> list, byte[] address)
        {
            IPAddress a1 = new IPAddress(address);
            IPAddressComparer ipc = new IPAddressComparer();
            int index = list.BinarySearch(a1, ipc);
            if (index >= 0) throw new Exception("IP address already exists in list");
            list.Insert(~index, a1);
        }
    
        public class IPAddressComparer : IComparer<IPAddress>
        {
            public int Compare(IPAddress x, IPAddress y)
            {
                byte[] xb = x.GetAddressBytes();
                byte[] yb = y.GetAddressBytes();
                for (int i = 0; i < 4; i++)
                {
                    int result = xb[i].CompareTo(yb[i]);
                    if (result != 0) return result; 
                }
                return 0;
            }
        }
    
    }
