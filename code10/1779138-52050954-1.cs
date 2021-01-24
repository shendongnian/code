    [HttpPost, Route("")]
    public IActionResult CreateMenu([FromBody] CreateMenuRequest createMenuRequest)
    {
        if (createMenuRequest != null)
        {
            createMenuRequest.UpdatedBy = HttpContext.GetUserId();
        }
        
        CreateMenuResponse createMenuResponse = _menuService.CreateMenu(createMenuRequest);
        return StatusCode(HttpStatusCode.Created.ToInt(), createMenuResponse);
    }
