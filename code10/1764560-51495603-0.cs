    private void SetupCustomer()
    {
        App.customers.Clear();
        var customer = new Customer { FirstName = "Timothy", LastName = "Jennings", Email = "tim.jennings@gmail.com", Phone = "0275 202020",
         Address = new Address { Street = "100 Burt Road", Suburb = "Howick", City = "Auckland", Country = "New Zealand" }
            };
         App.customers.Add(customer);
         customer = new Customer { FirstName = "Brian", LastName = "Jones", Email = "bjones@gmail.com", Phone = "0275 903070",
         Address = new Address { Street = "100 Vincent Road", Suburb = "St Lukes", City = "Auckland", Country = "New Zealand" }
            };
         App.customers.Add(customer);
         App.customers.Add(new Customer { FirstName = "Terry", LastName = "Teo", Email = "tete@mana.com", Phone = "021 756 382",
         Address = new Address { Street = "23 Ford St", City = "Auckland", Suburb = "Pakuranga", Country = "New Zealand" }
         });
    }
