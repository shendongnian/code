     public void ProcessRequest(HttpContext context)
     {
         // read from stream and process (above code)
   
         // output
         context.Response.ContentType = "application/json";
         context.Response.ContentEncoding = Encoding.UTF8;
         context.Response.Write(JsonConvert.SerializeObject(objToSerialize, new IsoDateTimeConverter()));
     }
