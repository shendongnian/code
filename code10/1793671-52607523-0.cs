    private void SetModifierMetadataOnChangedEntities()
    {
        foreach (var entityMetadataProvider in _entityMetadataProviders)
        {
            entityMetadataProvider.SetModifierMetadataOnChangedEntities(ChangeTracker);
        }
    }
