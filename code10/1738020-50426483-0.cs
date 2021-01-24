    [Route("en/blogs")]
    public class BlogController : Controller {
        //Match GET en/blogs/19
        //Match GET en/blogs/19/The-Automotive-Industry-Latest
        [HttpGet("{id:long}/{*slug?}")]
        [AllowAnonymous]
        public IActionResult GetBlog(long id, string slug = null) {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            
            if(blog == null)
                return NotFound();
            //TODO: verify title and redirect is not matching
                
            return Json(blog);
        }
    }
    
