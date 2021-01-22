    public string ClientName(int id)
    {
        return (from c in Context.Clients
                where c.Id == id
                select c.Name).FirstOrDefault();
    }
