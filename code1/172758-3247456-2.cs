    string entitySetName = context.MetadataWorkspace
                            .GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace)
                            .BaseEntitySets.Where(bes => bes.ElementType.Name == typeof(T).Name).First().Name;
    
    string name = String.Format("{0}.{1}", context.DefaultContainerName, entitySetName);
    
    query = context.CreateQuery<T>(name).Where(where);
