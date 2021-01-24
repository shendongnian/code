    public class Part
    {
        public long Id { get; private set; }
    
        [Index("UX_Warehouse_Color", 2, IsUnique = true)]
        public ColorEnum Color { get; private set; }
    
        public Bin Bin { get; private set; }
        public int BinId { get; private set; }
    
        public Warehouse Warehouse { get; private set; }
        [Index("UX_Warehouse_Color", 1, IsUnique = true)]
        public short WarehouseId { get; private set; }
    }
