    public class CartViewComponent : ViewComponent
    {        
        public IViewComponentResult Invoke(string name)
        {
            var totalItemCount = 3;
            return View(totalItemCount);
        }
    }
