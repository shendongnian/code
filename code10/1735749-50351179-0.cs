    CreateMap<SourceEntity, DestEntity>()
    .AfterMap((src, dest) =>
    {
        if (src != null)
        {
            dest = new DestEntity()
            {
                DestinationObjects = new List<SubDestinationEntity>()
            };
            dest.DestinationObjects.Add(new SubDestinationEntity()
            {
                Title = "Some text 1",
                Objects = src.List1
            });
            dest.DestinationObjects.Add(new SubDestinationEntity()
            {
                Title = "Some text 2",
                Objects = src.List2
            });
        }
    });
