    public string[] SearchForMovie(string SearchParameter)
    {
        //Format the search parameter so it forms a valid IMDB *SEARCH* url.
        //From within the search website we're going to pull the actual movie
        //link.
        string sitesearchURL = FindURL(SearchParameter);
        //Have a method download asynchronously the ENTIRE source code of the
        //IMDB *search* website, and save it to the byte[] "Buffer".
        WebClientX.DownloadDataCompleted += new DownloadDataCompletedEventHandler(WebClientX_DownloadSearchCompleted);
        WebClientX.DownloadDataAsync(new Uri(sitesearchURL));
    }
    void WebClientX_DownloadSearchCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        Buffer = e.Result;
        //Convert the byte[] to a string so we can easily find the *ACTUAL*
        //movie URL.
        string sitesearchSource = Encoding.ASCII.GetString(Buffer);
        //Pass the IMDB source code to method FindInformation() to FIND the movie
        //URL.
        string MovieURL = FindMovieURL(sitesearchSource);
        //Download the source code from the recently found movie URL.
        WebClientX.DownloadDataCompleted += new DownloadDataCompletedEventHandler(WebClientX_DownloadMovieCompleted);
        WebClientX.DownloadDataAsync(new Uri(MovieURL));
    }
    void WebClientX_DownloadMovieCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        Buffer = e.Result;
        //Convert the source code to readable string for scraping of information.
        string sitemovieSource = Encoding.ASCII.GetString(Buffer);
        // would create a movie object here rather than have the scrape function on this class
        string[] MovieInformation = ScrapeInformation(sitemovieSource);
        Model.LoadMovieInformation(MovieInformation);
    }
