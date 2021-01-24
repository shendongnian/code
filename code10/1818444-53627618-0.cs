    public IHttpActionResult AddItem([FromUri] string name) {
        try {
            // call service method
            return this.Ok();
        } catch (MyException1) {
            return this.NotFound();
        } catch (MyException2 e) {
            var error = new { message = e.Message }; //<-- anonymous object
            return this.Content(HttpStatusCode.Conflict, error);
        }
    }
    
