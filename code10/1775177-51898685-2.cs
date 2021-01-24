    public async Task<IActionResult> Download(string id) {
    	var headObject = await _oApi.Swift.HeadObject(containerId, id);
    
    	if (headObject.IsSuccess && headObject.ContentLength > 0) {
    		var fileName = headObject.GetMeta("Filename");
    		var contentType = headObject.GetMeta("Contenttype");
    
    		Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
    
    		var stream = new BufferedHTTPStream((start, end) => {
    			using (var response = _oApi.Swift.GetObjectRange(containerId, objectId, start, end).Result) {
	                var ms = new MemoryStream();
	                response.Stream.CopyTo(ms);
	                return ms;
               }    
    		}, () => headObject.ContentLength);
    
    		return new FileStreamResult(stream, contentType);
    	}
    
    	return new NotFoundResult();
    }
