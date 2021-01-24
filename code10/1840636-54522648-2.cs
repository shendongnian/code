    public enum ColorEnum : byte
    {
        Red = 1,
        Blue = 2
    }
    public class Part
    {
        public long Id { get; private set; }
        public ColorEnum Color { get; private set; }
        public Bin Bin { get; private set; }
        public int BinId { get; private set; }
    }
    public class Bin
    {
        public int Id { get; private set; }
        public Warehouse Warehouse { get; private set; }
        public short WarehouseId { get; private set; }
        public ICollection<Part> Parts { get; private set; }
    }
    public class Warehouse
    {
        public short Id { get; private set; }
        public ICollection<Bin> Bins { get; private set; }
    }
