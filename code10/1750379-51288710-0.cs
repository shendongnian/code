    public partial class Orders : EntityBase<int> {
    
        [PrimaryKey, AutoIncrement]
        public int Orderid { get; set; }
        protected Orders() { }
        public override int Id { get => base.Id; set => base.Id = Orderid; } 
    }
