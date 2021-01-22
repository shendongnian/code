    // GET: /Customer/Show/5
    public ActionResult Show(int id)
    {
        Customer customer = Customer.Load(id);
        ...  // some validation work
        var result = from c in cusomter
                     select new
                     {
                         Name = c.Name,
                         State = c.State,
                     };
        // or just
        var result = new
                     {
                         Name = customer.Name,
                         State = customer.State,
                     };
        return new XmlResult(result);
    }
