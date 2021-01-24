    private ActionResult<string> Single(SampleModel model)
    {
      return "Single";
    }
    private ActionResult<string> Multiple(SampleModel[] models)
    {
      return "Multiple";
    }
    private bool TryToObject<T>(JToken token, out T value)
    {
      try
      {
        value = token.ToObject<T>();
        return true;
      }
      catch (Exception) { }
      value = default(T);
      return false;
    }
    [HttpPost]
    [Route("")]
    public ActionResult<string> Post([FromBody] JToken token)
    {
      if (TryToObject(token, out SampleModel[] models))
        return Multiple(models);
      else if (TryToObject(token, out SampleModel model))
        return Single(model);
      else
        return BadRequest();
    }
