    Collection<String> connectedSsids = new Collection<string>();
    foreach (WlanClient.WlanInterface wlanInterface in wlan.Interfaces)
    {
       Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
       connectedSsids.Add(new String(Encoding.ASCII.GetChars(ssid.SSID,0, (int)ssid.SSIDLength)));
    }
