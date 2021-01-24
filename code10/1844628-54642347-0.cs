    private async Task TrackCurrentLocation()
    {
    var current = await CrossGeolocator.Current.GetPositionAsync();
    current.Accuracy = 30;
    float bearing =//bearing in case any
    var pins = new Pin { Label = "ME", Icon =''yourIcon"), Flat = true 
    };
    var latitude = current.Latitude;
    var longitude = current.Longitude;
    Device.BeginInvokeOnMainThread(() =>
    {
        pins.Position = new Position(latitude, longitude);
        pins.Rotation = bearing;
        if (MapTrack.Pins.Count == 0)
        {
            MapTrack.Pins.Add(pins);
        }
        else
        {
            MapTrack.Pins[0] = pins;
        }
        MapTrack.MoveCamera(CameraUpdateFactory.NewPosition(new Position(latitude, longitude)));
    });
    }
