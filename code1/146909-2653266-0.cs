    string inLat = "-80.987654";
    string inLon = "33.521478";
    var miles = GetNearestLocation(inLat, inLon);
    public double GetNearestLocation(string lat, string lon)
    {
        double dblInLat = double.Parse(lat);
        double dblInLon = double.Parse(lon);
        // instantiate the calculator
        GeodeticCalculator geoCalc = new GeodeticCalculator();
        // select a reference elllipsoid
        Ellipsoid reference = Ellipsoid.WGS84;
        // set user's current coordinates
        GlobalCoordinates userLocation;
        userLocation = new GlobalCoordinates(
            new Angle(dblInLon), new Angle(dblInLat)
        );
        // set example coordinates- when fully fleshed out, 
        //    this would be passed into this method
        GlobalCoordinates testLocation;
        testLocation= new GlobalCoordinates(
            new Angle(41.88253), new Angle(-87.624207) // lon, then lat
        );
        // calculate the geodetic curve
        GeodeticCurve geoCurve = geoCalc.CalculateGeodeticCurve(reference, userLocation, testLocation);
        double ellipseKilometers = geoCurve.EllipsoidalDistance / 1000.0;
        double ellipseMiles = ellipseKilometers * 0.621371192;
        /*
        Console.WriteLine("2-D path from input location to test location using WGS84");
        Console.WriteLine("   Ellipsoidal Distance: {0:0.00} kilometers ({1:0.00} miles)", ellipseKilometers, ellipseMiles);
        Console.WriteLine("   Azimuth:              {0:0.00} degrees", geoCurve.Azimuth.Degrees);
        Console.WriteLine("   Reverse Azimuth:      {0:0.00} degrees", geoCurve.ReverseAzimuth.Degrees);
        */
        return ellipseMiles;
    }
