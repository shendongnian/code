    [Route("Meetings/Edit/{id}")]
    [Authorize(Policy = "EditPolicy")]
    public async Task<IActionResult> Edit(int id)
    {
        MeetingView meetingView = new MeetingView();
    
        Meeting meeting = await _context.Meeting
            .Include(m => m.Room)
            .Include(m => m.MeetingType)
            .Include(m => m.CreatedBy)
            //.Include(m => m.UpdatedBy)
            .Include(m => m.Attendees)
            .AsNoTracking()
            .SingleAsync(m => m.IdMeeting == id);
    
        // Authorize the user against the EditPolicy using the meeting resource.
        var result = await _authorizationService.AuthorizeAsync(User, meeting, "EditPolicy");
        if (!result.Succeeded)
        {
            return Forbid();
        }
        // Do stuff.
    }
