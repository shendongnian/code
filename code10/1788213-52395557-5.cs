    public async Task<IActionResult> PartiallyUpdateBook([FromRoute] Guid id, [FromBody] JsonPatchDocument<BookModel> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest();
        }
        var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id)
        if (book == null)
        {
            return NotFound();
        }
        var bookToPatch = Mapper.Map<BookModel>(book);
        patchDoc.ApplyTo(bookToPatch, ModelState);
        TryValidateModel(bookToPatch);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        Mapper.Map(bookToPatch, book);
        _context.Entry(Book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
