    public class CustomerSearchViewModel {
        public IEnumerable<Customer> Customers { get; set; }
        public string SearchTerm { get; set; }
    }
    .....
    var viewModel = new CustomerSearchViewModel { 
                      Customers = customerList,
                      SearchTerm = searchTerm
                    };
    return View(viewModel);
