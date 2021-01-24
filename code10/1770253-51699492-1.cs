    [HttpPost]
    public async Task<IActionResult> PostTask([FromBody] NewTaskDto data) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        Models.Task task = MapDataToTask(data); //create Task and copy members
        _context.Task.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTask", new { id = task.ID }, task);
    }
