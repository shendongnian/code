    // This class will represent a video.
    // The names of the properties should match the names of your columns in your database.
    // Since I don't know the actual names of your columns, I'm taking a guess.
    public class Video
    {
        public int Id { get; set; }
    
        public string Title { get; set; }
    }
    
    // Your actual data access should happen in this class.
    // This keeps your UI code separated from your database logic
    public class SqlServerVideoRepository
    {
        readonly string _connectionString;
    
        public VideoRepository(string connectionString)
        {
            _connectionstring = connectionString;
        }
    
        public List<Video> LoadMostWatchedVideos()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                //Query is an extension method in the Dapper namespace
                return connection.Query<Video>("SELECT TOP (4) * FROM Video ORDER BY watched DESC").AsList();
            }
        }
    }
    
    
    //now in your code behind
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            var videoRepository = new SqlServerVideoRepository(ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString);
            var videos = videoRepository.LoadMostWatchedVideos();
            DtTopWatched.DataSource = videos;
            DtTopWatched.DataBind();
        }       
    }
