    public ActionResult Index()
    {
        var list = orderRepository.GetAll();
        return new AutoMapViewResult<Order, OrdersListModel>(null, null, list)
    }
