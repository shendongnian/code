        public class SomePageViewModel
        {
            private IAddressService _addressService;
            private IShoppingCartService _shoppingCartService;
            public SomePageViewModel(
                IAddressService addressService,
                IShoppingCartService shoppingCartService)
            {
                _addressService = addressService;
                _shoppingCartService = shoppingCartService;
            }
            public async Task GetDataAsync()
            {
                Address = await _addressService.GetAddressViewModelAsync();
                ShoppingCart = await _shoppingCartService.GetShoppingCartAsync();
            }
            public AddressViewModel Address { get; private set; }
            public ShoppingCartViewModel ShoppingCart { get; private set; }
        }
