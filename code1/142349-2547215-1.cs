    using (var client = new LiveRatesSoapClient())
    {
        var response = client.HotelSearch(new HotelSearchRequest
        {
            ApiKey = "THE_API_KEY_GOES_HERE",
            Checkin = new DateTime(2009, 7, 2),
            Checkout = new DateTime(2009, 7, 3),
            DisplayCurrency = "usd",
            Guests = 2,
            HotelID = 50563,
            LanguageCode = "en",
            Rooms = 1,
            TimeOutInSeconds = 90,
            UserAgent = "???",
            UserID = "???",
            UserIPAddress = "???"
        });
    }
