    public abstract class BaseController<T> : TableController<T>
    {
            protected override void Initialize(HttpControllerContext controllerContext)
            {
                base.Initialize(controllerContext);
                //Some code here...
            }
    
            // GET tables/TodoItem
            public abstract IQueryable<T> GetAllTodoItems();
            //More methods here
    }
