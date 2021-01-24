    [Route("[File/View/{id:int}", Name="FileView")]
    public async Task<IActionResult> View([FromRoute] int id)
    {
        return await Open(id, false);
    }
    
    [Route("[File/Download/{id:int}", Name="FileDownload")]
    public async Task<IActionResult> Download([FromRoute] int id)
    {
        return await Open(id, true);
    } 
    
    private async Task<IActionResult> Open(int Id, bool Download)
    {
        ....
    }
