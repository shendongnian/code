    public class MediaItemMap : ClassMap<MediaItem>
    {
        public MediaItemMap()
        {
            Table("MediaItem");
    
            Id(mi => mi.Id);
    
            Map(mi => mi.Title);
    
            HasManyToMany<Tag>(mi => mi.Tags)
                .Table("MediaItemsToTags").ParentKeyColumn("Id").ChildKeyColumn("Id")
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.SaveUpdate();
        }
    }
