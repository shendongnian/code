    public abstract class BaseController<T> : TableController<T>
    {
            protected override void Initialize(HttpControllerContext controllerContext)
            {
                base.Initialize(controllerContext);
                //Some code here...
            }
    
            // GET T/TodoItem
            public IQueryable<T> GetAllTodoItems()
            {
                  // your code here. T will be the right type but it'll be near on useless
            }
            //More methods here
    }
