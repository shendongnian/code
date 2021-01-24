    public virtual async Task<IHttpActionResult> GetAll()
    {
        ...
        return Ok(Service.GetAll().ToList().Select(MapToBindingModel));
    }
