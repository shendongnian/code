    [HttpGet("article/{id}/{slug}", Name = "ArticleDetailsIdSlug")]
    public IActionResult ArticleDetails(int id, string slug)
    
    [HttpGet("article/{slug}", Name = "ArticleDetailsSlug")]
    public IActionResult ArticleDetails(string slug)
