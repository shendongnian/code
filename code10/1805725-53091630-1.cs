    public void Map(IMapperConfigurationExpression expression)
    {
        expression.CreateMap<Category, DisplayCategoryViewModel>()
            .ForMember(viewModel => viewModel.Name, opts => opts.MapFrom(model => model.Title))                
            .ForMember(viewModel => viewModel.CreatedAt, opts => opts.ResolveUsing<UtcToLocalResolver, DateTime>(model => model.CreatedAt))
            .ForMember(viewModel => viewModel.UpdatedAt, opts => opts.ResolveUsing<UtcToLocalResolver, DateTime?>(model => model.UpdatedAt));
    }
