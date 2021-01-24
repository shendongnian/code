    protected override async void OnAppearing()
    {
        var request = new GeolocationRequest(GeolocationAccuracy.Best);
        var location = await Geolocation.GetLocationAsync(request);
        Position position = new Position(location.Latitude, location.Longitude);
        Geocoder geocoder = new Geocoder();
        var f = await geocoder.GetAddressesForPositionAsync(position);
    
        Debug.WriteLine(string.Join(",", f));
        Debug.WriteLine("exeuctie");
    }
