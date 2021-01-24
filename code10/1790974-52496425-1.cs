    public class RenameAction {
        //Some Kind of DbSet, Database Connection, external service,...
        //I'll go with an EF - DbSet<Warehouse> in this example
        private readonly DbSet<Warehouse>_warehouses;
        private readonly DbSet<StorageSystem> _storageSystem;
        
        public void Execute(int storageSystemId, int warehouseId, string name) {
            var storageSystem = _storageSystems.Single(system => system.Id == storageSystemId);
            if (_storageSystem.Warehouses.Any(wh => wh.Name == name))
                throw new BusinessLogicException("Warehouse names must be unique within storage systems!");
            var warehouse = storageSystem.Warehouses.Single(wh => wh.Id == warehouseId);
            warehouse.Name = name;
            //Write back the updated warehouse to whereever, this won't work with an DbSet<Warehouse>.
            _warehouses.Update(warehouse);
        }
    }
