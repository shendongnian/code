        CustomersViewModel ViewModel = new CustomersViewModel
        {
            CustomerList = customers
        };
        ViewBag.AnotherCustomers = ViewModel;
        return View();
