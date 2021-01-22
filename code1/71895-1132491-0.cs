    private static com.dev.webservices.Clinic[] GetClinicsNearLocation(Coordinate coordinate, int searchDistance)
    {
        var wsDental = new ProviderLocation_Dental();
        com.dev.webservices.Clinic[] clinics = wsDental.GetSearchResults(coordinate.Latitude, coordinate.Longitude, searchDistance);
        return clinics;
    }
