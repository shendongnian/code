    public class Field
    {
        [Key]
        public long Id { get; set; }
    
        public string FieldName { get; set; }
        [NotMapped]
        public bool IsModule 
        {
            get
            {
                return this.Module != null;
            }
        }
    
        public virtual Module Module {get; set;}
    }
    
    public class Module
    {
        [Key]
        public long Id { get; set; }
    
        public string ModuleName { get; set; }
    
        public virtual IEnumerable<Field> Fields { get; set }
    }
