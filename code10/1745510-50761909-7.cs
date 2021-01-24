    public static class RepositoryExtensions {
        public static async Task RemoveNonexistentEntities<TEntity, TEntityDto>(
            this IRepository<TEntity, Guid> repo, 
            IEnumerable<TEntity> repoItems, 
            IEnumerable<TEntityDto> dtoItems)
            where TEntity : class, IEntity<Guid>
            where TEntityDto : class, IEntityDto<Guid> {
            foreach (TEntity item in repoItems.ToList()) {
                if (dtoItems.All(x => x.Id != item.Id)) {
                    await repo.DeleteAsync(item.Id);
                }
            }
        }
    }
    
    // using
    _personPhonesRepository
        .RemoveNonexistentEntities(person.Phones, input.Phones);
