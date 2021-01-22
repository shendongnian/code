        try {
            return DAL.GetEntity<Entity>(id);
        }
        catch (DAL.NoSuchEntityException ex)
        {
            throw new FaultException<NotFoundFault>(
                new NotFoundFault {EntityId = ex.Id, ErrorMessage = "Can't find entity"});
        }
