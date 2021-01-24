    var OriginalCourse = await _context.Courses.SingleOrDefaultAsync(m => m.Url == courseUrl);
    if (OriginalCourse.Id != course.Id) {
        return NotFound();
    }
    if (ModelState.IsValid) {
        try {
            Populate(OriginalCourse, course);
            _context.Update(OriginalCourse);
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!CourseExists(course.Url)) {
                return NotFound();
            } else {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
