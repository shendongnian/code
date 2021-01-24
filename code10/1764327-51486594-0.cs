    public static class Mapper
    {
        public static void CreateMap()
        {
            TypeAdapterConfig<Property, PropertyDto>
                .NewConfig();
            TypeAdapterConfig<DropdownValue, DropdownValueDto>
                .NewConfig();
        }
    }
