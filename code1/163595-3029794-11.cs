    public interface IMovieRepository
    {
        Movie FindMovieById(string id);
        Movie FindMovieByTitle(string title);
    }
