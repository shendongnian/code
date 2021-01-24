    [HttpPut]
    [DisableFormValueModelBinding]
    public async Task<IActionResult> UploadSpreadsheet()
    {
        if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
        {
            return BadRequest($"Expected a multipart request, but got {Request.ContentType}");
        }
    
        var boundary = MultipartRequestHelper.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType), _defaultFormOptions.MultipartBoundaryLengthLimit);
        var reader = new MultipartReader(boundary, HttpContext.Request.Body);
    
        var section = (await reader.ReadNextSectionAsync()).AsFileSection();
    
        //If you're doing CSV, you add this line:
    	LoadOptions loadOptions = new LoadOptions(LoadFormat.CSV);
    
        var workbook = new Workbook(section.FileStream, loadOptions);
        Cells cells = workbook.Worksheets[0].Cells;
        var rows = cells.Rows.Cast<Row>().Where(x => !x.IsBlank);
    	
    	//Do whatever else you want here
