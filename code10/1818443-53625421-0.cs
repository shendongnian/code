    public class TestingMessage
    {
        [JsonProperty("message")]
        public string message{ get; set; }
    }
    
    public IHttpActionResult AddItem([FromUri] string name)
    {
        TestingMessage errormsg=new TestingMessage();
        try
        {
            // call service method
            return this.Ok();
        }
        catch (MyException1)
        {
            return this.NotFound();
        }
        catch (MyException2 e)
        {
            string error=this.Content(HttpStatusCode.Conflict, e.Message);
            errormsg.message=error;
            return errormsg;
        }
    }
