    [HttpGet]
    [Route("GetDisplayContainer/{id}")]
    public ApiResponse<ContainerDisplayViewModel> GetDisplayContainerRoute([FromRoute] Guid id)
    {
    }
