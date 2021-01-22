    public ShippingController
    {
        private readonly ProductService productService;
    
        public ShippingController(ProductService service)
        {
             productService = service;
        }        
        void ShipProduct(Product aProduct)   
        {
            service.Ship(aProduct);
        }
    }
