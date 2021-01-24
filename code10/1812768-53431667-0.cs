    // GET: CV_Website/Clients/ClientList
    [HttpGet]
    public ActionResult ClientList()
    {
        //using statement disposes the connection to the database once query has completed
        using (var context = new ClientContext())
        {
            //.ToList runs the query and maps the result to List<Client>
            var clients = context.Clients.ToList();
        }
    
        //Return view with list of clients as the model
        return View("ClientList", clients);
    }
