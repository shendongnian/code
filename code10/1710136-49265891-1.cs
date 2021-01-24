    [HttpPost]
            [Route("lastsaledate")]
            public async Task<IHttpActionResult> GetLastSalesUpdate(testClass myParam)
            {
                //do stuff
                return Ok(Result);
            }
    public class testClass
    {
       public string identifier;
       public bool endOfDay;
    }
