    [HttpPost]
    public IActionResult Post([FromForm]PostcodeVerwerking postcode)
    {
       int res = _postcodeRepo.AddPostcode(postcode); 
       if (res != 0)
       {
           return Ok();
       }
        return Forbid();
    }
