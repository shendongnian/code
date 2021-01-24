    public class AttributeMap : ClassMap<Attribute>
    {
        public AttributeMap()
        {
            Id(a => a.Id);
            Map(a => a.Name);
            Map(a => a.Classification);
        }
    }
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(r => r.Id);
            Map(r => r.Name);
            HasManyToMany(r => r.Attributes)
        }
    }
