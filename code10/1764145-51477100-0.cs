    config.CreateMap<Type2, TypeDto>()
            .ForMember(dest => dest.Children, opts => opts.Ignore())
            .AfterMap((d,e) => AddNestedChildren(d, e));
    private void AddNestedChildren(Type2 type, TypeDto dto)
    {
        foreach (var child in type.Nested)
        {
            var childDto = dto.Children.SingleOrDefault(c => c.Id == child.Id);
            // keep old properties
            Mapper.Map(child, childDto);
        }
    }
