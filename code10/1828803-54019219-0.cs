    [HttpPost]
    [Route("assign/{id}")]
    public async Task<IActionResult> AssignRoom(int sectionId, [FromBody] SaveRoomSectionAssignmentResource resource)
    {
              // some code here
    }
