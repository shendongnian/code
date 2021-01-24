    var postArticle = () => {
        event.preventDefault();
        var Article = new FormData(this.event.target);
        console.log([...Article]);
        fetch('/api/Articles', {
            method: "POST",
            body: Article
        })
    }
    // POST: api/Articles
        [HttpPost]
        public async Task<IActionResult> PostArticle([FromForm]Article article)
        {
            string name = article.Title;
            if (!ModelState.IsValid)
            {
                return Ok();
            }
            //_context.Article.Add(article);
            //await _context.SaveChangesAsync();
            return Ok(); //CreatedAtAction("GetArticle", new { id = article.Id }, article);
        }
