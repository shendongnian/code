    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        //[Authorize]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            AuthContext db = new AuthContext();
            var user = db.Users.Single(x => x.UserName == "BartBart");
            var gebruikerid = user.Id;
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return Ok(string.Format("id:{0}", gebruikerid));
            //return Ok(Order.CreateOrders());
        }
    
    }
