    public partial class Orders : EntityBase<int>
    {
        protected Orders() { }
        public int Orderid { get; set; }
        public override int Id { get => Orderid; set => Orderid = value; }
    }
