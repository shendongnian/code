    [Test]
    public void Can_add_new_case()
    {
        var newCase = new Case();
        var entity1 = new Entity();
        var entity2 = new Entity();
        newCase.EntityCollection.Add(entity1, Roles.Role1);
        newCase.EntityCollection.Add(entity2, Roles.Role2);
        Rhino.Commons.NHRepository<Entity> entityRepository = new NHRepository<Entity>();
        Rhino.Commons.NHRepository<Case> caseRepository = new NHRepository<Case>();
        
        using (UnitOfWork.Start())
        {
            entityRepository.SaveOrUpdate(entity1);
            entityRepository.SaveOrUpdate(entity2);
            caseRepository.SaveOrUpdate(newCase);
        }
    }
