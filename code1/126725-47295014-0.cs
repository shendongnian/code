     NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler((sender, e, ...otherParametersIfYouWant) => AvailabilityChangedCallback(sender, e, ...)); 
    private void AvailabilityChangedCallback(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
            //Internet Connection is available   
            }
         }
