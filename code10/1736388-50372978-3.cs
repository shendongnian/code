    [Route("GetTestFile")]
    [HttpGet]
    public IActionResult GetTestFile()
    {
        var fileName = "testdata.csv";
        var filePath = Path.Combine("Data", fileName);
        try
        {
            return new FileContentResult(File.ReadAllBytes(filePath), "text/csv") { FileDownloadName = fileName };
        }
        catch (Exception exception)
        {
            var errorMessage = $"Can not read CSV file {fileName}.";
            Log(errorMessage, exception);
            return StatusCode((int)HttpStatusCode.InternalServerError, errorMessage);
        }
    }
