    public IHttpActionResult BlahMethod([FromBody] TestObject data)
    {
      string id = data.id;
      var Props = data.properties;
      User existing = _context.MyClass.Where(x => x.Properties.Any(y => y.PropertyLabel == "app" && y.PropertyValue == id)).FirstOrDefault();
      if (existing == null)
        return NotFound();
      return Ok(existing);
    }
