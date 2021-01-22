    public IQueryable<ClientEntity> GetClients(Expression<Func<ClientModel, bool>> criteria)
        {
            return (
                from model in Context.Client.AsExpandable()
                where criteria.Invoke(model)
                select new Ibfx.AppServer.Imsdb.Entities.Client.ClientEntity()
                {
                    Id = model.Id,
                    ClientNumber = model.ClientNumber,
                    NameFirst = model.NameFirst,
                    //more propertie here
                }
            );
        }
