    public class EntityMetadataProvider : IEntityMetadataProvider
    {
    
        public EntityMetadataProvider()
        {       
        }
        public void SetModifierMetadataOnChangedEntities(ChangeTracker changeTracker)
        {
            var entriesToSetModifier = changeTracker.Entries<BaseEntity>().Where(e => 
    HasToSetModifierMetadata(e.State)).ToList();
    
            if (entriesToSetModifier.Count > 0)
            {
                var saveDate = DateTime.UtcNow;
                foreach (var entryToSetModifier in entriesToSetModifier)
                {
                    SetModifierMetadataProperties(entryToSetModifier, saveDate);
                }
            }
        }
    ...
