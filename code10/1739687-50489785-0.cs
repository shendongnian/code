    [HttpPost]
    [ResponseType(typeof(IEnumerable<СompositeType>))]
    public HttpResponseMessage Test(string cox, [FromBody] Test str)
    {
       ...    
    }
     
