    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var @event = await Mediator.Send(new DeleteCourseCommand {Id = id});
        if(@event is CourseNotFoundEvent)
            return NotFound();
        return NoContent();
    }
