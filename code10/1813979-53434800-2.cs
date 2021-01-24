    if (course != null)
    {
        _context.Courses.Remove(course);
        var saveResult = await _context.SaveChangesAsync(cancellationToken);
        if (saveResult <= 0)
        {
            throw new DeleteFailureException(nameof(course), request.Id, "Database save was not successful.");
        }
    }
    else
    {
        throw new NotFoundException(nameof(Course), request.Id);
    }
    return Unit.Value;
