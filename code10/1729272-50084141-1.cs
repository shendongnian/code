    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public IActionResult GetPostById(string id)
    {
            var post = <<Your logic here>>;
            return Json(post);
        }
