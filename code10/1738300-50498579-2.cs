        public MokaKukaTrackerDbContext(DbContextOptions<MokaKukaTrackerDbContext> options, IDomainEventHandlingsExecutor domainEventHandlingsExecutor) : base(options)
        {
            _domainEventHandlingsExecutor = domainEventHandlingsExecutor;
        }
        public override int SaveChanges()
        {
            var numberOfChanges = base.SaveChanges();
            _domainEventHandlingsExecutor.Execute(GetDomainEventEntities());
            return numberOfChanges;
        }
        private IEnumerable<IEntity> GetDomainEventEntities()
        {
            return ChangeTracker.Entries<IEntity>()
                .Select(po => po.Entity)
                .Where(po => po.Events.Any())
                .ToArray();
        }
