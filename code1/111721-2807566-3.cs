    public class ComponentA
    {
        public virtual string Name { get; set; }
    }
    public class EntityF : Entity
    {
        private IDictionary<string, ComponentA> _components = new Dictionary<string, ComponentA>();
        public IDictionary<string, ComponentA> Components
        {
            get { return _components; }
            set { _components = value; }
        }
    }
    public class EntityFMap : IAutoMappingOverride<EntityF>
    {
        public void Override(AutoMapping<EntityF> mapping)
        {
            mapping.HasMany<ComponentA>(x => x.Components)
                .AsMap<string>("IndexKey")
                .KeyColumn("EntityF_Id")
                .Table("EntityF_Components")
                .Component(x =>
                               {
                                   x.Map(c => c.Name);
                               })
                .Cascade.AllDeleteOrphan();
        }
    }
