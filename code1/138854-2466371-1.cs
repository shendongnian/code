    public void ProcessClients(List<Client> tempClients)
    {
        foreach (Client client in tempClients)
        {
            Client originalClient = ctx.Clients.Where(a => a.Id == client.Id).SingleOrDefault();
        
            if (originalClient != null)
            {
                originalClient.ArrivalTime = client.ArrivalTime;
                originalClient.ClientId = client.ClientId;
                originalClient.ClientName = client.ClientName;
                originalClient.ClientEventTime = client.ClientEventTime;
                originalClient.EmployeeCount = client.EmployeeCount;
                originalClient.ManagerId = client.ManagerId;
            }
            else
            {
                ctx.Clients.InsertOnSubmit(client);
            }
        }
    
        ctx.SubmitChanges();
    }
