    public class Part
    {
        public long Id { get; private set; }
        [Index("UX_Bin_Color", 2, IsUnique = true)]
        public ColorEnum Color { get; private set; }
        public Bin Bin { get; private set; }
        [Index("UX_Bin_Color", 1, IsUnique = true)]
        public int BinId { get; private set; }
    }
