    public class ApplicationFormAnswer
    {
         [Key]
         public Guid Id { get; set; }
         public Guid ApplicationFormId { get; set; }
         [ForeignKey("ApplicationFormId")]         
         public virtual ApplicationForm ApplicationForm { get; set; }
         //...
    }
    public class ApplicationForm
    {
         [Key]
         public Guid Id { get; set; }
         //...
    }
