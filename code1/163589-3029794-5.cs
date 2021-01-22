    public class MovieRepository : IMovieRepository
    {
        private readonly IHtmlDownloader _downloader;
        public MovieRepository(IHtmlDownloader downloader)
        {
            _downloader = downloader;
        }
        public Movie FindMovieById(string id)
        {
            var idUri = ...build URI...;
            var html = _downloader.DownloadHtml(idUri);
            return ...parse ID HTML...;
        }
        public Movie FindMovieByTitle(string title)
        {
            var titleUri = ...build URI...;
            var html = _downloader.DownloadHtml(titleUri);
            return ...parse title HTML...;
        }
    }
