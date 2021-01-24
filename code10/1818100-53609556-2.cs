    [Table("MyTable")]
    public class EntityBasic
    {
        [Key]
        public Guid MyTableId { get; set; }
    
        public Guid ParentId { get; set }
    
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        public int Type { get; set; }
    
        [ForeignKey("ParentId")]
        public virtual List<EntityBasic> Entities{ get; set; }
    }
    public class EntityAdvanced : EntityBasic
    {    
        [NotMapped]
        public string ImageUrl
        {
            get { //Some complicated getter }
            set { //Some complicated setter }
        }
    
        public void SetFilters(//Some parameters)
        {
            //Some logic 
        }
    }
