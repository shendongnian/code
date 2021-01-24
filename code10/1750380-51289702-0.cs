    public partial class Orders : EntityBase<int>
    {
        protected Orders() { }
        [Column("Orderid")]
        public int Id { get; set; }
    }
