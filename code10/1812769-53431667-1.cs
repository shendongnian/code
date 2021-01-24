    // GET: CV_Website/Clients/Edit/1
    [HttpGet]
    public ActionResult Edit(int id)
    {
        using (var context = new ClientContext())
        {
            //Using Linq, select the client with the matching ID or return null
            var client = context.Clients.SingleOrDefault(c => c.Id == id);
        }
       
        return View("ClientList", client);
    }
