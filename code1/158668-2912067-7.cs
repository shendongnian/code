    public ActionResult Edit(int id)
    {
        Order order = null; // OrderService.Get(id);
        IList<Customer> customers = null; // CustomerService.GetAll();
    
        OrderFormViewModel model = OrderFormViewModel.Create(order);
        model.Customers = customers.Select(c => new SelectListItem {
            Value = c.Id,
            Text = c.Name
        });
    
        return View(model);
    }
    [HttpPost]
    public ActionResult Edit(int customerId, Order order)
    {
        //customerId - selected from dropdown.
    }
    
    public class OrderFormViewModel
    {
        public static OrderFormViewModel Create(Order order)
        {
            return new OrderFormViewModel {
                Order = order
            };
        }
        
        public Order Order { get; internal set; }
        public IEnumerable<SelectListItem> Customers { get; internal set; }
        public int CustomerId { get; internal set; }
    }
