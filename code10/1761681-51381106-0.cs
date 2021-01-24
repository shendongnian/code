    public class ApplicationFormAnswer
    {
         [Key]
         public Guid Id { get; set; }
         public string FieldId { get; set; }
         public ApplicationCustomFieldType FieldType { get; set; }
         public string Name { get; set; }
         public string Answer { get; set; }
         public virtual ApplicationForm ApplicationForm { get; set; }
         public Guid ApplicationFormId { get; set; }
    }
