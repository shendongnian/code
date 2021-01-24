    [HttpGet("{id}", Name = "GetTodoList")]
    public ActionResult<TodoList> GetById(int id)
    {
        var item = _context.TodoList.Find(id);
        _context.TodoList.Include(x => x.Todos).ToList();
        if (item == null)
        {
            return NotFound();
        }
        return item;
    } 
