    public class VehiculeMap: ClassMapping<Vehicule>
    {
        public VehiculeMap()
        {
            Table("G1Vehicule");
    
            Id(x => x.Id, map => { map.Column("id"); });
            Property(x => x.Brand, map => { map.Column("brand"); });
            Property(x => x.Color, map => { map.Column("color"); });
            Property(x => x.UserID, map => { map.Column("user_id"); });
            ManyToOne(x => x.User, map => {
                map.Column("user_id"),
                map.Fetch(FetchKind.Join),
                map.notFound(NotFoundMode.Ignore)
            })
        }
    }
