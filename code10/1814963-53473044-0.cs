    public async Task<Geocoding.Location> GetCoordinates()
    {
         IEnumerable<Address> addresses = await geocoder.GeocodeAsync(FullAddress);
         return addresses.First().Coordinates;
    }
