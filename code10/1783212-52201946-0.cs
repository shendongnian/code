    var internetStatus = Reachability.InternetConnectionStatus();
    switch(internetStatus)
    {
        case NetworkStatus.ReachableViaCarrierDataNetwork:
            // do something on cellular network
            break;
        case NetworkStatus.ReachableViaWiFiNetwork:
            // do something on wifi network
            break;
    }
