    [HttpGet]
    public JsonResult GetAll()
    {
        var objectList =  _context.Objects.Select(o => new
                {
                   o.ObjectId,
                   Tags = o.ObjectTags.Select(ot => ot.Tag).ToList()
                }).ToList();
         return Json(objectList);
    }
