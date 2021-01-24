    [HttpGet]
    public ActionResult<List<ObjectDto>> GetAll()
    {
        var objectList =  _context.Objects.Select(o => new ObjectDto
                {
                   ObjectId = o.ObjectId,
                   Tags = o.ObjectTags.Select(ot => ot.Tag).ToList()
                }).ToList();
         return objectList;
    }
