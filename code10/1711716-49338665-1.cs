    // Define an enum for Genre and populate with as many Genres you want.
    enum Genre { Action, Adventure, Animation, Biography, Comedy, Crime }
    // Define an enum for Rating and populate it accordingly
    enum Rating { GeneralAudiences, ParentalGuidanceSuggested, ParentsStronglyCautioned, Restricted, AdultsOnly }
    class Movie
    {
        public int Id { get; }
        public string Name { get; }
        public DateTime ReleaseDate { get; }
        public string Location { get; }
        public Genre Genre { get; }
        public Rating Rating { get; }
        // Prefer decimal for money. It's more accurate than double.
        public decimal Price { get; }
        public Movie(int id, string name, DateTime releaseDate, string location, Genre genre, Rating rating, Decimal price)
        {
            Id = id;
            // It's meaningless we talk about for a Movie without a name. 
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ReleaseDate = releaseDate;
            Location = location;
            Genre = genre;
            Rating = rating;
            Price = price;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, ReleaseDate: {ReleaseDate.ToString("MM/dd/yyyy")}, Location: {Location}, Genre: {Genre}, Rating: {Rating}";
        }
    } 
