    public interface IViewDataWrapper
    {
        List<CartItem> ShoppingCart { get; set; }
    }
    public class ViewDataWrapper : IViewDataWrapper
    {
    }
    public class BaseController : Controller
    {
        public IViewDataWrapper ViewDataWrapper { get; set; }
    
        public BaseController()
        {
            IViewDataWrapper = new ViewDataWrapper();
        }
    }
