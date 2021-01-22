    public class DataForMasterPageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //initiate your repository
               var catRepository = ...;
            //then create the viewdata like so
            filterContext.Controller.ViewData["Categorias"] = new SelectList(catRepository.FindAllCategorias().AsEnumerable(), "id", "nome", 3);
        }
    }
