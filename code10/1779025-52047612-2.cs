    public class ReviewController : ApiController
    {
        ...
       
        [Route("api/review/site/{siteId}")]
        [HttpGet]
        public IEnumerable<Review> FindStoreBySite(int SiteID)
        {
             return db.Review.Where(review => review.Id == SiteID);
        }
    
        ...
