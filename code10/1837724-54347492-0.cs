    container.RegisterAs<PartnerRepository, IPartnerRepository>();
    container.Register<IDtoRepository<Db.PartnerProperty, Db.PartnerProperty, Db.PartnerProperty>>(c =>
    {
       var repository = new DtoRepository<Db.PartnerProperty, Db.PartnerProperty, Db.PartnerProperty, Db.PartnerProperty>();
       c.AutoWire(repository);
       return repository;
    });
