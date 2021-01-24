    public async Task Invoke(HttpContext context) {
        Exception exception = null;
        try {
            await _next(context);
        }
        catch (Exception e) {
            exception = e;
            //try handling exception stuff...
        }
    
        //try handling 415 code stuff...
        if(context.Response.StatusCode==415){
            var yourJsonObj = new { Blah = "blah..." };
            string result = JsonConvert.SerializeObject(yourJsonObj);
            //context.Response.StatusCode = 200; //You can change the StatusCode here
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }
