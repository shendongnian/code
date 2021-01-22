    public class SystemFilesMap : ClassMap<SystemFiles>
    {
        public SystemFilesMap()
        {
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.Name).Column("name");
            Map(x => x.ContentType).Column("contenttype");
            Map(x => x.Data).Column("data");
        }
    }
