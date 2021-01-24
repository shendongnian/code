    private void btn_add_movie_Click(object sender, RoutedEventArgs e)
    {
        string m = input_movie_name.Text;
        Movie NewMovie = new Movie { Name = m };
        this.movielistInstance.AddMovie(NewMovie);
    }
