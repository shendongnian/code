    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap ()
        {
            // Single table
            Table("EntityTable");
            // ID
            Id(x => x.Id, "EntityId")
                .GeneratedBy
                .HiLo("NHibernateHilo", "HighId", "1", "EntityId=1");
            // References
            References(x => x.Object, "ReferenceFieldId").Cascade.SaveUpdate();
            // Properties
            Map(x => x.PropertyName, "FieldName");
        }
    }
