    public class Item
    {
        public int Id { get; set; }
        public int ParentItemId { get; set; }
        public virtual Item ParentItem { get; set; }
        public virtual ICollection<Item> ChildItems { get; set; }
    }
            modelBuilder.Entity<Item>()
                .HasRequired(entity => entity.ParentItem)
                .WithMany(entity => entity.ChildItems)
                .HasForeignKey(entity => entity.ParentItemId);
