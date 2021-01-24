    [HttpGet]
    [Route("api/file/")]
    public async Task<IHttpActionResult> GetFileBy([FromUri] FilesBySha256AndDateRequestDTO requestDTO)
    {
    	if (!requestDTO.from_date.HasValue && !requestDTO.to_date.HasValue)
    	{
    		return await this.GetFileBySha256Async(new FilesBySha256RequestDTO() { sha256 = requestDTO.sha256 });
    	}
    	else
    	{
    		return await this.GetFileBySha256AndDateAsync(requestDTO);
    	}
    }
    
    private async Task<IHttpActionResult> GetFileBySha256Async(FilesBySha256RequestDTO requestDTO)
    {            
    }
    
    private async Task<IHttpActionResult> GetFileBySha256AndDateAsync(FilesBySha256AndDateRequestDTO requestDTO)
    {
    }
