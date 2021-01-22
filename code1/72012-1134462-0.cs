    private void DeleteOrphans<TEntity, TRelatedEntity>(Func<TEntity, EntityCollection<TRelatedEntity>> collectionAccessor)
            where TEntity : EntityObject
            where TRelatedEntity : EntityObject
        {
            ObjectStateManager.ObjectStateManagerChanged += (_, e) =>
            {
                if (e.Action == System.ComponentModel.CollectionChangeAction.Add)
                {
                    var entity = e.Element as TEntity;
                    if (entity != null)
                    {
                        var collection = collectionAccessor(entity) as System.Data.Objects.DataClasses.EntityCollection<TRelatedEntity>;
                        if (collection != null)
                        {
                            collection.AssociationChanged += (__, e2) =>
                            {
                                if ((e2.Action == System.ComponentModel.CollectionChangeAction.Remove))
                                {
                                    var relatedEntity = e2.Element as TRelatedEntity;
                                    if (relatedEntity != null)
                                    {
                                        DeleteObject(relatedEntity);
                                    }
                                }
                            };
                        }
                    }
                }
            };
        }
