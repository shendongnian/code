    [ResponseType(typeof(Author))]
    public async Task<IHttpActionResult> GetAuthor(string name)
    {
        Author author = await db.Authors.Where(a => a.Name == name).FirstOrDefaultAsync();
        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }
