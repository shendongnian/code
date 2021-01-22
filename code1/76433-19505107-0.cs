    var twitterCtx = new TwitterContext(auth);
    string status = "Testing TweetWithMedia #Linq2Twitter " +
    DateTime.Now.ToString(CultureInfo.InvariantCulture);
    const bool PossiblySensitive = false;
    const decimal Latitude = StatusExtensions.NoCoordinate; 
    const decimal Longitude = StatusExtensions.NoCoordinate; 
    const bool DisplayCoordinates = false;
    
    string ReplaceThisWithYourImageLocation = Server.MapPath("~/test.jpg");
     
    var mediaItems =
           new List<media>
           {
               new Media
               {
                   Data = Utilities.GetFileBytes(ReplaceThisWithYourImageLocation),
                   FileName = "test.jpg",
                   ContentType = MediaContentType.Jpeg
               }
           };
     
     Status tweet = twitterCtx.TweetWithMedia(
        status, PossiblySensitive, Latitude, Longitude,
        null, DisplayCoordinates, mediaItems, null);
