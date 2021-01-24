    public ObservableCollection<SearchMovie> PopularMovies { get; } 
        = new public ObservableCollection<SearchMovie>(); 
    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var popularMovies = await client.GetMoviePopularListAsync("en", 1);
      
        PopularMovies.Clear();
        foreach(var movie in popularMovies)
            PopularMovies.Add(movie); 
    }
