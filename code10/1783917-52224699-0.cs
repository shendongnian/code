    public IActionResult Credit([FromBody] Data data)
    {
       var x = Report();
       return Ok(new {Active = x.Item1, UserName = x.Item2});
    }
