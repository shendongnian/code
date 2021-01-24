    public class Cart : ViewComponent
        {
            private readonly ICartService _cartService;
    
            public Cart(ICartService cartService)
            {
                _cartService = cartService;
            }
    
            public async Task<IViewComponentResult> InvokeAsync()
            {
                return View("~/Pages/Components/Cart/Default.cshtml", await _cartService.GetCart());
            }
        }
