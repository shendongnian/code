    cfg.CreateMap<SourceEntity, DestEntity>(MemberList.None)
       .ConstructUsing(sourceItem =>
       {
           var destItem = new DestEntity
           {
               DestinationObjects = new List<SubDestinationEntity>()
           };
           if (sourceItem.List1.Any())
           {
               destItem.DestinationObjects.Add(new SubDestinationEntity
               {
                   Title = "Some text 1",
                   Objects = sourceItem.List1
               });
           }
           if (sourceItem.List2.Any())
           {
               destItem.DestinationObjects.Add(new SubDestinationEntity
               {
                   Title = "Some text 2",
                   Objects = sourceItem.List2
               });
           }
           return destItem;
       });
