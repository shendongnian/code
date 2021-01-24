    public class UserController : ODataController
    {
        [HttpGet]
        [System.Web.OData.Routing.ODataRoute("User({userId})/Tags")]
        public IHttpActionResult GetTags([FromODataUri]int userId)
        {
            //...
        }
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        public List<Tag> Tags { get; set; }
    }
