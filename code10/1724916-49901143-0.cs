    [HttpPost]
    public ActionResult AddClient([FromBody]ClientDto client) {
        if(ModelState.IsValid) {
            using(var clientContext = new ClientContext()) {
                var clientToAdd = new Client { 
                    Comment = client.Comment, 
                    Company = client.Company, 
                    Website = client.Website
                };
                clientContext.Clients.Add(clientToAdd);
                clientContext.SaveChanges();
            }
        }
        return View();
    }
