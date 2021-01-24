    [HttpGet]
    [Route("GetDisplayContainer/{id}")]
    public ApiResponse<ContainerDisplayViewModel> GetDisplayContainer(Guid id)
    {
        return ApiResponse.Convert(ResourceService, _containerService.GetDisplayContainerById(id));
    }
