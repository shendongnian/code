    public class Item
    {
       [Key]
        public string ItemId { get; set; }
        public virtual ICollection<ExplicitMod> ExplicitMods { get; private set; } = new List<ExplicitMod>();
    }
