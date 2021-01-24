    //Your rest of code is same here
    
    List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(data);
    
    tickets.ForEach(t =>
    {
        Ticket ticket = new Ticket()
        {
            Id = t.Id,
            Requester = t.Requester,
            PrjName = t.PrjName,
            Categorie = t.Categorie,
            ClientName = t.ClientName,
            Service = t.Service,
            Description = t.Description,
            Status = t.Status
        };
        tview = ticket;
        await DocumentDBRepository<Ticket>.CreateItemAsync(tview);
    });
    
    //Your rest of code is same here
