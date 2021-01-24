    public class TopNavViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Code to instantiate the model class.
            var yourModelClass = ...
            return View(yourModelClass);
        }
    }
