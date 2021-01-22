    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI",
    "SELECT * FROM MSNdis_80211_ServiceSetIdentifier");
    
    foreach (ManagementObject queryObj in searcher.Get())
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("MSNdis_80211_ServiceSetIdentifier instance");
        Console.WriteLine("-----------------------------------");
    
        if(queryObj["Ndis80211SsId"] == null)
            Console.WriteLine("Ndis80211SsId: {0}",queryObj["Ndis80211SsId"]);
        else
        {
            Byte[] arrNdis80211SsId = (Byte[])
            (queryObj["Ndis80211SsId"]);
            foreach (Byte arrValue in arrNdis80211SsId)
            {
                Console.WriteLine("Ndis80211SsId: {0}", arrValue);
            }
        }
    }
