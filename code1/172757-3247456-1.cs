    string entitySetName = context.MetadataWorkspace
                            .GetEntityContainer(context.DefaultContainerName, System.Data.Metadata.Edm.DataSpace.CSpace)
                            .BaseEntitySets.Where(bes => bes.ElementType.Name == typeof(T).Name).FirstOrDefault().Name;
    
    string name = String.Format("{0}.{1}", context.DefaultContainerName, entitySetName);
    
    query = context.CreateQuery<T>(name).Where(where);
