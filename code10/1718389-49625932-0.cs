    public class TodoRepository : ITodoRepository
    {
        public bool ValidateTodo(Todo todo)
        {
            //some validation
            throw new ValidationException("Invalid todo");
        }
    }
    
    public class MyBusinessExceptionFilterAttribute : ExceptionFilterAttribute {
        ...
    }
    
    public static void ApplicationStartup() {
        ...
        GlobalFilters.Filters.Add(new MyBusinessExceptionFilterAttribute());
        ...
    }
    
    public IActionResult Post(Todo todo)
    {
        // Just let the exception to be thrown in case of business errors
        _todoRepository.ValidateTodo(todo);
    }
