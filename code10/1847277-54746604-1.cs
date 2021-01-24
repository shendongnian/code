    [Produces("application/json")]
    [Route("api/Blog")]
    public class BlogController : Controller
    {
        // TODO : Move the connection string to configuration
        string sqlstring = "server=; port= ; user id =;Password=;Database=;";
        // GET: api/Blog
        /// <summary>
        /// <para>Retrieves the given record from the database</para>
        /// </summary>
        /// <param name="id">Identifier for the required record</param>
        /// <returns>JSON object with the data for the requested object</returns>
        [HttpGet]
        public IEnumerable<string> Get(int id)
        {
            IDbConnection dbConnection = System.Data.Common.DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
            RetrieveDataClass dal = new RetrieveDataClass(dbConnection);
            EventDataModel data = dal.GetDataEvent(id);
            if (data != null)
            {
                // Using Newtonsoft library to convert the object to JSON data
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                // TODO : Not sure if you need IEnumerable<string> as return type
                return new List<string>() { output };
            } else
            {
                // TODO : handle a record not found - usually raises a 404
            }
        }
        // TODO : other methods
    }
