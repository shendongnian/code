    public class Item : ClassMap<Item>
    {
      Id(x=>x.Id)
        .Column("ItemId");
    
      Map(x=>x.Name);
    
      HasMany(x=>x.RelatedItems)
        .KeyColumn("RelatedId")
        .Table("RelatedItems")
        .LazyLoad()
        .AsList();    
    }
