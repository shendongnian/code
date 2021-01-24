    [HttpPost]
    public async Task<IActionResult> PostTask([FromBody] NewTaskDto data) {
        if(data != null) {
            validateUserId(data.UserId, ModelState);
        }
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        Models.Task task = MapDataToTask(data); //create Task and copy members
        await saveTask(task);
        return CreatedAtAction("GetTask", new { id = task.ID }, task);
    }
