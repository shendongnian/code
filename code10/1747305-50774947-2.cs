    Mapper.Initialize(cfg => cfg.CreateMap<ModelDto, ModelBase>().ConstructUsing(x => 
    {
        switch (x.ModelType)
        {
            case ModelType.One:
                return new ModelOne { Name = x.Name };
            case ModelType.Two:
                return new ModelTwo { Name = x.Name };
            default:
                throw new InvalidOperationException("Unknown ModelType...");
        }
    }));
