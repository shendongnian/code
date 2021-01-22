    [ActiveRecord(Lazy = true)]
    public class Lookup : ActiveRecordBase<Lookup>
    {
        [HasMany(typeof(LookupItem), Cascade = ManyRelationCascadeEnum.All)]
        public virtual IList Items { set; get; }
     
        //other properties...
    }
    [ActiveRecord(Lazy = true)]
    public class LookupItem : ActiveRecordBase<LookupItem>
    {
        [BelongsTo("Lookup_id")]
        public virtual Lookup ContainerLookup { set; get; }
        //other properties...
    }
    void SaveLookup()
    {
        Lookup lookup = GetLookup();
        LookupItem lookupItem = new LookupItem()
        {
            Title = LookupItemName,
            ContainerLookup = lookup
        };
        lookup.Items.Add(lookupItem);
        lookup.Save();
    }
