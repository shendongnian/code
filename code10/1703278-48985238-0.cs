    public IActionResult orderBy([FromQuery] string fields)
    {
      string[] _fields = fields.Split(',');
      try {
      PropertyInfo[] Props = _fields.Select(field => typeof(Product).GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) ).ToArray();
      var query = _context.Product
                          .AsNoTracking()
                          .OrderBy(p => Props.First().GetValue(p));
      for (int i = 0; i < Props.Count(); i++)
        query = query.ThenBy(p => Props[i].GetValue(p));
        return Ok( query.ToList() );
      }
      catch (Exception ex) {
        return BadRequest(new { Title = ex.GetType().Name, Error = ex });
      }
    }
