    [HttpPost, Route("myobjects/route/")]
    public async Task<IHttpActionResult> SaveMyObjectAsync()
    {
        if (Request.Content.IsMimeMultipartContent() == false)
        {
            return StatusCode(HttpStatusCode.BadRequest);
        }
        var contentStreamProvider = await Request.Content.ReadAsMultipartAsync();
        var stream = new FileStream("LocalStreamFile.json", FileMode.Create);
        foreach (var content in contentStreamProvider.Contents)
        {
            //read out the chunk and convert from json
            var requestArray = JsonConvert.DeserializeObject<byte[]>(await content.ReadAsStringAsync(), JsonSettings.Default);
            stream.Write(requestArray, 0, requestArray.Length);
        }
        stream.Seek(0, SeekOrigin.Begin);
        var formatter = new BinaryFormatter();
        //convert back from stream to our original large object
        var request = (MyObject)formatter.Deserialize(stream);
        //save to database etc
        ...
        return Ok();
    }
