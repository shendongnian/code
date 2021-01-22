    DataLoadOptions loadOptions = new DataLoadOptions();
    loadOptions.LoadWith<Entity>(e => e.Relation);
    SomeEntity someEntity = someEntityRepository
      .Get(new Guid("98011F24-6A3D-4f42-8567-4BEF07117F59"),
      loadOptions);
//
    using (DataContext context = new DataContext())
    {
      context.LoadOptions = loadOptions;
