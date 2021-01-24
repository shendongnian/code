    try
    {
        var ConnectionProfiles = NetworkInformation.GetConnectionProfiles();
        if (ConnectionProfiles != null)
        {
            Debug.WriteLine(ConnectionProfiles.Count);
            foreach (var profile in ConnectionProfiles)
            {
                //Profile name
                var name = profile.ProfileName;
    
                NetworkUsageStates networkUsageStates = new NetworkUsageStates();
                networkUsageStates.Roaming = TriStates.DoNotCare;
                networkUsageStates.Shared = TriStates.DoNotCare;
                //get the data usage from the last 30 day
                DateTime startTime = DateTime.Now.AddDays(-30);
                DateTime endTime = DateTime.Now;
                var usages = await profile.GetNetworkUsageAsync(startTime,
                    endTime, DataUsageGranularity.Total, networkUsageStates);
                if (usages != null)
                {
                    foreach (var use in usages)
                    {
                        //Data usage.
                        var TotalDataUsage = use.BytesReceived + use.BytesSent;
                    }
                }
            }
        }
    }
    catch (Exception e)
    {
        Debug.WriteLine(e.Message);
    }
