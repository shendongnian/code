    //GET api/Ifcobjects
    [HttpGet]
    [Route("")]
    public IHttpActionResult Get() {
        return Ok(Ifcobjects);
    }
    //GET api/Ifcobjects/1
    [HttpGet]
    [Route("{id:int}")]
    public IHttpActionResult Get(int id) {
        var Ifcobject = Ifcobjects.FirstOrDefault(s => s.Id == id);
        if (Ifcobject == null) {
            //return NotFound();
            return Content(HttpStatusCode.NotFound, "Ifcobject not found");
        }
        return Ok(Ifcobject);
    }
    //GET api/Ifcobjects/Ifcwall
    [HttpGet]
    [Route("{Ifctype:alpha}")]
    public IHttpActionResult Get(string ifctype) {
        var results = Ifcobjects.Where(s => s.Ifctype.ToLower() == ifctype.ToLower()).ToList();
        if(results.Count == 0) {
            return Content(HttpStatusCode.NotFound, "ifctype not found");
        }
        return Ok(results);
    }
    
