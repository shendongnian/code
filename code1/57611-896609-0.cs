    public class ComponentRegistrar
    {
        public static void AddComponentsTo(IWindsorContainer container) {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            container.AddComponent("validator",
                typeof(IValidator), typeof(Validator));
        }
        private static void AddCustomRepositoriesTo(IWindsorContainer container) {
            container.Register(
                AllTypes.Pick()
                .FromAssemblyNamed("Northwind.Data")
                .WithService.FirstNonGenericCoreInterface("Northwind.Core"));
        }
        private static void AddGenericRepositoriesTo(IWindsorContainer container) {
            container.AddComponent("entityDuplicateChecker",
                typeof(IEntityDuplicateChecker), typeof(EntityDuplicateChecker));
            container.AddComponent("repositoryType",
                typeof(IRepository<>), typeof(Repository<>));
            container.AddComponent("nhibernateRepositoryType",
                typeof(INHibernateRepository<>), typeof(NHibernateRepository<>));
            container.AddComponent("repositoryWithTypedId",
                typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));
            container.AddComponent("nhibernateRepositoryWithTypedId",
                typeof(INHibernateRepositoryWithTypedId<,>), typeof(NHibernateRepositoryWithTypedId<,>));
        }
    }
