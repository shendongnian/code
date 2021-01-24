    [Table("Class")]
    public class Class
    {
        public Class()
        {
            this.ClassDetailListing = new List<ClassDetail>();
        }
        [Key]
        public int Id { get; set; }       
        public string Name { get; set; }       
        public int Capacity { get; set; }
    }
    [Table("ClassDetail")]
    public class ClassDetail
    {
        public ClassDetail()
        {
            this.ClassInfo = new Class();
        }
        [Key]
        public int Id { get; set; }        
        public int ClassId { get; set; }        
        public string DayOfWeek { get; set; }        
        public string StartTime { get; set; }        
        public string EndTime { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class ClassInfo { get; set; }
    }
