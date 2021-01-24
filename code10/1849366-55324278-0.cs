    [HttpPatch]
    [EnableQuery]
    public IHttpActionResult Patch(int key, Delta<EmployeeDetail> patch)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var entity = _db.EmployeeDetails.Find(key);
        patch.Patch(entity);
        _db.SaveChanges();
        // Return content by default
        // Disable this by sending in header { Prefer: "return=minimal" }
        if (!this.Request.Headers.Any(k => k.Key.Equals("prefer", StringComparison.OrdinalIgnoreCase) || k.Key.Equals("preference", StringComparison.OrdinalIgnoreCase)))
            this.Request.Headers.Add("Prefer", "return=representation");
        return Updated(entity);
    }
