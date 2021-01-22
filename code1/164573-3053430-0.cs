    <pre><code>
    SelectQuery query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=2");
    ManagementObjectSearcher search = new ManagementObjectSearcher(query);
    foreach(ManagementObject result in search.Get()) {
     NetworkAdapter adapter = new NetworkAdapter(result);
     // Identify the adapter you wish to disable here. 
     // In particular, check the AdapterType and 
     // Description properties.
     // Here, we're selecting the LAN adapters.
     if (adapter.AdapterType.Contains("Ethernet 802.3")) {
        adapter.Disable();
     }
    }
