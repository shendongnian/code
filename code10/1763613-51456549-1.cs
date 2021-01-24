    public abstract class MyBaseController<T> : Controller where T : IResource {
        [HttpGet]
        public async Task<ActionResult<T>> doSomething() {
            // ...
        }
    }
