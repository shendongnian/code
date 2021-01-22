    public class TitleHtmlDownloader : IHtmlDownloader
    {
        public HtmlDocument DownloadHtml(Uri uri)
        {
            return ...create document from saved HTML...
        }
    }
    [Test]
    public void ParseTitle()
    {
        var movies = new MovieRepository(new TitleHtmlDownloader());
        var movie = movies.GetByTitle("The Matrix");
        Assert.AreEqual("The Matrix", movie.Title);
        
        ...assert other values from the HTML...
    }
