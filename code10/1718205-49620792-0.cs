    public async Task<IHttpActionResult> MyAction() {
        //...code removed for brevity
        var response = await client.GetAsync("{url}");
        if (response.IsSuccessStatusCode) {
            var message = Request.CreateResponse(HttpStatusCode.OK);
            message.Content = response.Content;
            return ResponseMessage(message);
        }
        return BadRequest(); //or some other status response.
    }
