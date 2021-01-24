    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasOptional(entity => entity.LinkedItem)
            .WithRequired(entity => entity.Item);
        modelBuilder.Entity<Item>()
            .HasMany(entity => entity.ChildItems)
            .WithRequired(entity => entity.ParentItem)
            .HasForeignKey(entity => entity.ParentItemId);
    }
    [Table("Item")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public virtual ICollection<LinkedItem> ChildItems { get; set; }
        public virtual LinkedItem LinkedItem { get; set; }
    }
    [Table("LinkedItem")]
    public class LinkedItem
    {
        [Key]
        public int ItemId { get; set; }
        public int ParentItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual Item ParentItem { get; set; }
    }
