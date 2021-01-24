    public class LadderEntityBase : ICloneable
    {
        public LadderEntityBase(Guid pk)
        {
            PK = pk;
        }
        public LadderEntityBase() : this(Guid.NewGuid())
        {
        }
        public Guid PK { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class Order : LadderEntityBase
    {
        public Order() : base()
        {
        }
        public Order(Guid guid) : base(guid)
        {
        }
        public string OrderFrom { get; set; }
    }
    public class Parcel : LadderEntityBase
    {
        public Parcel() : base()
        {
        }
        public Parcel(Guid guid) : base(guid)
        {
        }
        public string SentTo { get; set; }
    }
