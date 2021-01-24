    public class MyEntityHistoryStore : IEntityHistoryStore
    {
        private readonly IRepository<Audited> _auditedRepository;
        public MyEntityHistoryStore(IRepository<Audited> auditedRepository)
        {
            _auditedRepository = auditedRepository;
        }
        public async Task SaveAsync(EntityChangeSet entityChangeSet)
        {
            foreach (var entityChange in entityChangeSet.EntityChanges)
            {
                var entityType = entityChange.EntityEntry.As<EntityEntry>().Entity.GetType();
                foreach (var propertyChange in entityChange.PropertyChanges)
                {
                    var property = entityType.GetProperty(propertyChange.PropertyName);
                    if (property.IsDefined(typeof(ToBeAuditedAttribute)))
                    {
                        await _auditedRepository.InsertAsync(new Audited
                        {
                            EntityId = JsonConvert.DeserializeObject<int>(entityChange.EntityId),
                            FieldName = propertyChange.PropertyName,
                            FieldValue = propertyChange.NewValue
                        });
                    }
                }
            }
        }
    }
