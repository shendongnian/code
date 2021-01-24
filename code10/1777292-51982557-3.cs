        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(CustomerViewModel model)
        {
             //preceeding code
        var customer = db.Customers.SingleOrDefault(x => x.CustomerId == model.CustomerId)
        if (customer.Address == null)
        {
            var address = new Address()
            {
                StreetName = customer.Address.StreetName
            };
            Customer.Addresses.Add(address);
        }
        }
