    public class ExplicitMod       
    {
        public ExplicitMod()
        {}
        public ExplicitMod(string name)
        {
            Name = name;
        }
        [Key]
        public string ExplicitModId { get; set; } 
        [ForeignKey("Item")]
        public string ItemId{ get; set; }
        public string Name { get; set; }
        public virtual Item Item { get; set; }
    }
