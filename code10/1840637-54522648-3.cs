    public class Part
    {
        public long Id { get; private set; }
    
        public ColorEnum Color { get; private set; }
    
        public Bin Bin { get; private set; }
        public int BinId { get; private set; }
    
        public Warehouse Warehouse { get; private set; }
        public short WarehouseId { get; private set; }
    }
