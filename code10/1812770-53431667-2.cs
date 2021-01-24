    // POST: CV_Website/Clients/Edit/{Client}
    [HttpPost]
    public ActionResult Edit(Client client)
    {
        using (var context = new ClientContext())
        {
            //Get client from database
            var clientInDb = context.Clients.SingleOrDefault(c => c.Id == client.ID);
    
            //Update client using properties from the client parameter
            clientInDb.Age = client.Age;
            clientInDb.Gender = client.Gender;
            clientInDb.Name = client.Name;
            clientInDb.Surname = client.Surname;
    
            //Commit changes to the database
            context.SaveChanges();
        }
    
        return View("ClientList", client);
    }
