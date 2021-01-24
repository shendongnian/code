    public static class RepositoryExtensions
    {
        public static List<TEntity> GetAllInOuIncludingChildren<TEntity, TPrimaryKey>(
            this IRepository<TEntity, TPrimaryKey> repository,
            long organizationUnitId
        )
            where TEntity : class, IEntity<TPrimaryKey>, IMustHaveOrganizationUnit
        {
            using (var organizationUnitRepository = repository.GetIocResolver().ResolveAsDisposable<IRepository<OrganizationUnit, long>>())
            {
                var code = organizationUnitRepository.Object.Get(organizationUnitId).Code;
                var query =
                    from entity in repository.GetAll()
                    join organizationUnit in organizationUnitRepository.Object.GetAll() on entity.OrganizationUnitId equals organizationUnit.Id
                    where organizationUnit.Code.StartsWith(code)
                    select entity;
                return query.ToList();
            }
        }
    }
