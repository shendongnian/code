    using (var context = new AppEntities())
    {
        var container = context.MetadataWorkspace.GetEntityContainer("AppEntities", System.Data.Metadata.Edm.DataSpace.CSpace);
        foreach (var entitySet in container.BaseEntitySets.OfType<EntitySet>())
        {
            var elementType = entitySet.ElementType;
            foreach (var np in elementType.NavigationProperties)
            {
                if (np.FromEndMember.DeleteBehavior == OperationAction.Cascade)
                {
                    var entityType = np.FromEndMember.GetEntityType();
                    // do stuff...
                }
                if (np.ToEndMember.DeleteBehavior == OperationAction.Cascade)
                {
                    var entityType = np.ToEndMember.GetEntityType();
                    // do stuff...
                }
            }
        }
    }
