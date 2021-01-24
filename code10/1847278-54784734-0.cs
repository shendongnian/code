    [Produces("application/json")]
    [Route("api/Blog")]
    public class BlogController : Controller
    {
    // GET: api/Blog
    [HttpGet]
     public List<BlogViews>  Get()
        {
        
                string sqlstring = "server=; port= ; user id =;Password=;Database=;";
                MySqlConnection conn = new MySqlConnection(sqlstring);
                try
                {
                    conn.Open();
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                string Query = "SELECT * FROM test.blogtable where `Telephone` ='Created'";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                MySqlDataReader MSQLRD = cmd.ExecuteReader();
                List<BlogViews> GetBlogList = new List<BlogViews>();
                if (MSQLRD.HasRows)
                {
                  while (MSQLRD.Read())
                  {
                    BlogViews BV = new BlogViews();
                    BV.id = (MSQLRD["id"].ToString());
                    BV.DisplayTopic = (MSQLRD["Topic"].ToString());
                    BV.DisplayMain = (MSQLRD["Summary"].ToString());
                    GetBlogList.Add(BV);
                  }
                }
                conn.Close();
            return GetBlogList;
        }
    // GET: api/Blog/5
    [HttpGet("{id}", Name = "GetBlogItems")]
    public string Get(int id)
    {
    }
    // POST: api/Blog
    [HttpPost]
    public void Post([FromBody]  RetrieveDataClass value)
    {
        string sqlstring = "server=; port= ; user id =;Password=;Database=;";
        MySqlConnection conn = new MySqlConnection(sqlstring);
        try
        {
            conn.Open();
        }
        catch (MySqlException ex)
        {
            throw ex;
        }
        string Query = "INSERT INTO test.blogtable (id,Telephone,CreatedSaved,Topic,Summary,Category,Body1,Body2,Body3,Body4)values('" + value.TopicSaved1 + "','" + Value.Telephone + "','" + Value.Created/Saved + "','" + value.TopicSaved1 + "','" +value.SummarySaved1 +"','" +value.CategoriesSaved1 +"','" +value.Body1 +"','" +value.Body2 +"','" +value.Body3 +"','" +value.Body4 +"');";
        MySqlCommand cmd = new MySqlCommand(Query, conn);
        cmd.ExecuteReader();
        conn.Close();
    }
    // PUT: api/Blog/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }
    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
