    public class UnitOfWork : IUnitOfWork
    {
        private readonly BomConfiguratorContext _context;
        public IRuleRepository Rules { get; private set; }
    
        // here you inject a BomConfiguratorContext, but none is registered in the VM Locator
        public UnitOfWork(BomConfiguratorContext context)
        {
            _context = context;
        }
    
        ...
    }
