    public class GenreViewModel
    {
            public int GenreId { get; set; }
            public string GenreName { get{ return Enum.GetName(typeof(Genre), GenreId);}}
    }
