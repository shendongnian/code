    Resource1 resource = MapperFactory.GetRelatedMapper(entity1)
        .MapToResource(entity1) as Resource1;
    public static class MapperFactory
    {
        public static IMapper<T, BaseResource> GetRelatedMapper<T>(T entity)
            where T : BaseEntity
        {
            switch (entity)
            {
                case Entity1 _:
                    return new Entity1Mapper() as IMapper<T, BaseResource>;
                case Entity2 _:
                    return new Entity2Mapper() as IMapper<T, BaseResource>;
                default:
                    throw new NotImplementedException();
            }
        }
    }
