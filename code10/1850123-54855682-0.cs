    [Route("FindMembersWith")]
    [HttpGet]
    public IActionResult FindMembersFor([FromQuery(Name = "eyeColor")] string eyeColor)
    {
       return Ok(DoSomeOtherMethodWithFilter(eyeColor);
    } 
    [Route("GetAllMembers")]
    [HttpGet]
    public IActionResult GetAllMembers()
    {
        return Ok(DoMethodToRetrieveAllMembers);
    }
