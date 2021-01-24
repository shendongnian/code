    [Route("en/blogs")]
    public class BlogController : Controller {
        //Match GET en/blogs/19
        //Match GET en/blogs/19/the-automotive-industry-latest
        [HttpGet("{id:long}/{*slug?}",  Name = "blogs_endpoint")]
        [AllowAnonymous]
        public IActionResult GetBlog(long id, string slug = null) {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            
            if(blog == null)
                return NotFound();
            
            //TODO: verify title and redirect if they do not match
            if(!string.Equals(blog.slug, slug, StringComparison.InvariantCultureIgnoreCase)) {
                slug = blog.slug; //reset the correct slug/title
                return RedirectToRoute("blogs_endpoint",  new { id = id, slug = slug });
            }
            
            return Json(blog);
        }
    }
    
