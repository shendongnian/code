    const string GeoCodeUrlFormat = "http://maps.google.com/maps/geo?q={0}&output=csv&oe=utf8&sensor=false&key={1}";
    string location = "State St, Troy, NY";
    string googleApiKey = "fromAppConfigOrSomething";
    string url = String.Format(GeoCodeUrlFormat,
        HttpUtility.UrlEncode(location), HttpUtility.UrlEncode(googleApiKey));
    HttpRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
    HttpResponse response = (HttpResponse)request.GetResponse(); // Can throw an exception
    Stream responseStream = response.GetResponseStream();
    using (StreamReader reader = new StreamReader(responseStream)
    {
        string firstLine = reader.ReadLine();
        string[] lineParts = firstLine.Split();
        GeolocationResult result = GoogleMapper.MapGeolocationResult(lineParts);
        // TADA
    }
