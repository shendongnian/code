    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
        var usageStates = new NetworkUsageStates
        {
            Roaming = TriStates.DoNotCare,
            Shared = TriStates.DoNotCare
        };
        var networkUsage = await internetConnectionProfile.GetNetworkUsageAsync(
                DateTimeOffset.Now.AddDays(-1),
                DateTimeOffset.Now,
                DataUsageGranularity.Total,
                usageStates);
        foreach (var usage in networkUsage)
        {
            Debug.WriteLine(internetConnectionProfile.ProfileName+" Sent: "+usage.BytesSent+" Received: "+usage.BytesReceived);
        }
    }
