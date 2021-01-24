    [HttpGet("List/{ids}")]
    public async Task<ActionResult<ViewItemModel[]>> List([ModelBinder(typeof(EnumerableBinder))]HashSet<int> ids)
    {
        //code
    }
