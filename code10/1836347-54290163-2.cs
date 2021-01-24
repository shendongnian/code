    //* -. space to create a "MarkAsComplete" method
    //PUT: api/todo/5
    [HttpPut("{id:long}")]        
    public async Task<ActionResult<ToDoItem>> MarkAsComplete(long id) {
        var todoitem = await _context.ToDoItems.FindAsync(id);
        if (todoitem == null) {
            return NotFound();
        } else {
            todoitem.IsComplete = true;
        }
        return todoitem;
    }
    //*/
