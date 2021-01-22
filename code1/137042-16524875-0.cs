    private Movie movie;
    public Movie Movie
    {
        get { return movie; }
        set
        {
            var oldProperties = typeof(Movie).GetProperties();
            foreach (var property in oldProperties)
            {
                if (property.GetValue(movie).GetHashCode() != value.GetType().GetProperty(property.Name).GetValue(value).GetHashCode())
                {
                    RaisePropertyChanged(property.Name);
                }
            }
            movie = value;
        }
    }
