    // POST: api/Messages
    [HttpPost]
    public async Task<ActionResult<Message>> PostMessage(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        var message = await _context.Messages
                        .Include(i=>i.MessageBoard)
                        .FirstOrDefaultAsync(i => i.Id == message.Id);
        return Json(message);
    }
