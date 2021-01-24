    public async Task<IHttpActionResult> GetEmployee([FromUri] int eId)
    {
        var res = GetService<IEmployeeService>().GetEmployeeById(eId);
        return res == null ? (IHttpActionResult)NotFound() : Ok(res);
    }
