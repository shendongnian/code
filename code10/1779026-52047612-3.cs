    [Route("api/getFoo/{id}")]
    public IHttpActionResult GetFoo(int id)
    {
        return db.Foo.Where(x => x.Id == id);
    }
