    [HttpGet]
    public IHttpActionResult Get(params)
    {
        var result = "";
        using (var memoryStream = new MemoryStream())
        {
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter))
            {
                csvWriter.WriteRecords(listOfObjects);
            } 
            result = Convert.ToBase64String(memoryStream.ToArray()); 
        }
        return Ok(result);
    }
