    public async Task<IActionResult> PartiallyUpdateBook([FromRoute] Guid id, [FromBody] JsonPatchDocument<BookModel> patchDoc)
    {
        // If the received data is null
        if (patchDoc == null)
        {
            return BadRequest();
        }
        // Retrieve book from database
        var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id)
        // Check if is the book exist or not
        if (book == null)
        {
            return NotFound();
        }
        // Map retrieved book to BookModel with other properties (More or less with eexactly same name)
        var bookToPatch = Mapper.Map<BookModel>(book);
        // Apply book to ModelState
        patchDoc.ApplyTo(bookToPatch, ModelState);
        // Use this method to validate your data
        TryValidateModel(bookToPatch);
        // If model is not valid, return the problem
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // Assign entity changes to original entity retrieved from database
        Mapper.Map(bookToPatch, book);
        // Say to entity framework that you have changes in book entity and it's modified
        _context.Entry(Book).State = EntityState.Modified;
        // Save changes to database
        await _context.SaveChangesAsync();
        // If everything was ok, return no content status code to users
        return NoContent();
    }
