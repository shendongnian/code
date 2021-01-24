    public class OrderMapping : ClassMapping<Order>
    {
        public OrderMapping()
        {
            Table("Orders");
            Lazy(false);
            ComponentAsId(a => a.EntityId, a => { a.Property(x => x.DbId, x => x.Column("Id")); });
            Property(a => a.CustomerName);
            Property(a => a.RegisterDatetime);
            IdBag(a => a.Items, map => {
                map.Access(Accessor.Field);
                map.Table("OrderItems");
                map.Key(a => a.Column("OrderId"));
                map.Id(a => {
                    a.Column("Id");
                    a.Generator(Generators.Identity);
                });
            }, relation => relation.Component(map => {
                map.Access(Accessor.Field);
                map.Property(a => a.Number, a => a.Access(Accessor.Field));
                map.Property(a => a.Goods, a => a.Access(Accessor.Field));
                map.Property(a => a.UnitPrice, a => a.Access(Accessor.Field));
            }));
        }
    }
