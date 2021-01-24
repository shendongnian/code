    async Task StartListeningAsync()
    {
        if(CrossGeolocator.Current.IsListening)
            return;
        
        await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true);
        CrossGeolocator.Current.PositionChanged += PositionChanged;
        CrossGeolocator.Current.PositionError += PositionError;
    }
    private void PositionChanged(object sender, PositionEventArgs e)
    {
        //If updating the UI, ensure you invoke on main thread
        var position = e.Position;
        var output = "Full: Lat: " + position.Latitude + " Long: " + position.Longitude;
        output += "\n" + $"Time: {position.Timestamp}";
        output += "\n" + $"Heading: {position.Heading}";
        output += "\n" + $"Speed: {position.Speed}";
        output += "\n" + $"Accuracy: {position.Accuracy}";
        output += "\n" + $"Altitude: {position.Altitude}";
        output += "\n" + $"Altitude Accuracy: {position.AltitudeAccuracy}";
        Debug.WriteLine(output);
    } 
    private void PositionError(object sender, PositionErrorEventArgs e)
    {
        Debug.WriteLine(e.Error);
        //Handle event here for errors
    } 
    async Task StopListeningAsync()
    {
        if(!CrossGeolocator.Current.IsListening)
            return;
        
        await CrossGeolocator.Current.StopListeningAsync();
        CrossGeolocator.Current.PositionChanged -= PositionChanged;
        CrossGeolocator.Current.PositionError -= PositionError;
    }
