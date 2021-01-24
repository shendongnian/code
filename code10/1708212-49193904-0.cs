    [EnableQuery]
    [ODataRoute("Code({id})")]
    public SingleResult<Code> GetCode(long id)
    {
      return SingleResult.Create(_codes.AsQueryable().Where(x => x.Id == id));
    }
