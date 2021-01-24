    public class RecordTypeConfiguration : EntityTypeConfiguration<RecordType>
    {
        public RecordTypeConfiguration()
        {
            HasKey(i => i.Id);
    
            Property(e => e.RecordType).HasColumnType("VARCHAR").HasMaxLength(1);
            Property(t => t.RecordType).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("Ix_RecordType"){IsUnique = true}));
    
         }
    }
