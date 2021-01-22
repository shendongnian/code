    using (var entitiesEfContext = new ContextABC())
    {
        var platforms = Builder<Platform>
                                    .CreateListOfSize(4)
                                    .TheFirst(1)
                                    .With(x => x.Description = "Desc1")
                                    .With(x => x.IsDeleted = false)
                                    .TheNext(1)
                                    .With(x => x.Description = "Desc2")
                                    .With(x => x.IsDeleted = false)
                                    .TheNext(1)
                                    .With(x => x.Description = "Desc3")
                                    .With(x => x.IsDeleted = false)
                                    .TheNext(1)
                                    .With(x => x.Description = "Desc4")
                                    .With(x => x.IsDeleted = false)
                                    .Build();
                    foreach (var platform in platforms)
                    {
                        entitiesEfContext.Platform.AddObject(platform);
                    }
                    entitiesEfContext.SaveChanges();
                  // the identity insert row (o as id in my case)
                   entitiesEfContext.ExecuteStoreCommand("SET IDENTITY_INSERT Platform ON; INSERT INTO [Platform](Platformid,[Description],[IsDeleted],[Created],[Updated]) VALUES (0,'Desc0' ,0 ,getutcdate(),getutcdate());SET IDENTITY_INSERT Platform Off");
                  }
