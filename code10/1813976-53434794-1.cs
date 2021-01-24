    public async Task<IActionResult> Delete(int id)
    {
        var courseWasFound = await Mediator.Send(new DeleteCourseCommand {Id = id});
    
        if (!courseWasFound)
            return NotFound();
    
        return NoContent();
    }
