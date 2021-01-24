    public class BlockHeader : ViewComponent
    {
        public IViewComponentResult Invoke(string buttonText, string blockTitle, string message)
        {
        	// ...
            return View<string>(message);
        }
    }
